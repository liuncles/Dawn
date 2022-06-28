using Dawn.Commons.Hubs;
using Dawn.Extensions.Middlewares;
using Dawn.Extensions.Middlewares.UseLoadTest;

namespace Dawn.IS4.API
{
    public class AppConfigure
    {
        /// <summary>
        /// 配置HTTP请求管道
        /// </summary>
        /// <param name="app"></param>
        /// <exception cref="Exception"></exception>
        public static void Configure(IApplicationBuilder app, IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            app.UseIpLimitMiddle();               // Ip限流,尽量放管道外层
            app.UseRequestResponseLogMiddle();    // 记录请求与返回数据
            app.UseRecordAccessLogsMiddle();      // 用户访问记录(必须放到外层，不然如果遇到异常，会报错，因为不能返回流)
            app.UseSignalRSendMiddle();           // signalr
            app.UseIpLogMiddle();                 // 记录ip请求
            app.UseAllServicesMiddle(services);   // 查看注入的所有服务

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // 在开发环境中，使用异常页面，这样可以暴露错误堆栈信息，所以不要放在生产环境。
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // 在非开发环境中，使用HTTP严格安全传输(or HSTS) 对于保护web安全是非常重要的。
                // 强制实施 HTTPS 在 ASP.NET Core，配合 app.UseHttpsRedirection
                //app.UseHsts();
            }

            app.UseSession();
            app.UseSwaggerAuthorized();

            // 封装Swagger展示
             app.UseSwaggerMiddle(() => new object().GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Dawn.IS4.API.index.html"));

            // ↓↓↓↓↓↓ 注意下边这些中间件的顺序，很重要 ↓↓↓↓↓↓

            app.UseCors(AppSettings.App(new string[] { "Startup", "Cors", "PolicyName" }));  // CORS跨域
            //app.UseHttpsRedirection();                                                     // 跳转https

            // 使用静态文件
            DefaultFilesOptions defaultFilesOptions = new();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();

            app.UseCookiePolicy();               // 使用cookie
            app.UseStatusCodePages();            // 返回错误码
            app.UseRouting();                    // Routing
            // app.UseJwtTokenAuth();            // 这种自定义授权中间件，可以尝试，但不推荐

            // 测试用户，用来通过鉴权
            if (configuration.GetValue<bool>("AppSettings:UseLoadTest"))
            {
                app.UseMiddleware<ByPassAuthMiddleware>();
            }

            app.UseAuthentication();             // 先开启认证
            app.UseAuthorization();              // 然后是授权中间件
            app.UseMiniProfilerMiddleware();     // 开启性能分析
            //app.UseExceptionHandlerMidd();     // 开启异常中间件，要放到最后

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/api2/chatHub");
            });

            var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var tasksQzServices = scope.ServiceProvider.GetRequiredService<ITasksQzServices>();
            var schedulerCenter = scope.ServiceProvider.GetRequiredService<ISchedulerCenterServer>();
            var lifetime = scope.ServiceProvider.GetRequiredService<IHostApplicationLifetime>();

            app.UseSeedDataMiddle(appContext, env.WebRootPath);              // 生成种子数据
            app.UseQuartzJobMiddleware(tasksQzServices, schedulerCenter);    // 开启QuartzNetJob调度服务
            app.UseConsulMiddle(configuration, lifetime);                    // 服务注册
            //app.ConfigureEventBus();                                       // 事件总线，订阅服务
        }
    }
}
