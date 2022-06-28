using Dawn.Commons.GlobalVar;
using Dawn.Commons.Helper;
using Dawn.Commons.Log;
using Dawn.Extensions.Services;
using Dawn.IS4.API.Attribute;
using Dawn.IS4.API.Filter;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Dawn.IS4.API
{
    public class ServicesConfigure
    {
        /// <summary>
        /// 向容器添加服务
        /// </summary>
        /// <param name="services"></param>
        /// /// <param name="configuration"></param>
        /// <param name="env"></param>
        public static void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddSingleton(new AppSettings(configuration));
            services.AddSingleton(new LogLock(env.ContentRootPath));
            services.AddUiFilesZipSetup(env);

            Authorization.IsUseIS4 = AppSettings.App(new string[] { "Startup", "IdentityServer4", "Enabled" }).ObjToBool();
            RoutePrefix.Name = AppSettings.App(new string[] { "AppSettings", "SvcName" }).ObjToString();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();   // 确保从认证中心返回的ClaimType不被更改，不使用Map映射

            services.AddMemoryCacheSetup();
            services.AddRedisCacheSetup();

            services.AddSqlsugarSetup();
            services.AddDbSetup();
            services.AddAutoMapperSetup();
            services.AddCorsSetup();
            services.AddMiniProfilerSetup();
            services.AddSwaggerSetup();
            services.AddTasksSetup();                                    // 任务调度服务
            services.AddHttpContextSetup();
            //services.AddAppConfigSetup(env);
            services.AddAppTableConfigSetup(env);                        // 表格打印配置
            services.AddHttpApi();
            services.AddRedisInitMqSetup();

            services.AddRabbitMQSetup();
            services.AddKafkaSetup(configuration);
            services.AddEventBusSetup();
            services.AddNacosSetup(configuration);

            // 授权+认证 (jwt or is4)
            services.AddAuthorizationSetup();
            if (Authorization.IsUseIS4)
            {
                services.AddAuthenticationIS4Setup();
            }
            else
            {
                services.AddAuthenticationJWTSetup();
            }

            services.AddIpPolicyRateLimitSetup(configuration);
            services.AddSignalR().AddNewtonsoftJsonProtocol();
            services.AddScoped<UseServiceDIAttribute>();
            services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
                    .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpPollySetup();

            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter));                                               // 全局异常过滤
                //o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());                             // 全局路由权限公约
                o.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(RoutePrefix.Name)));  // 全局路由前缀，统一修改路由
            })

            // 这种写法也可以
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //})

            //MVC全局配置Json序列化处理
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;   // 忽略循环引用
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();       // 不使用驼峰样式的key
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";               // 设置时间格式
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;         // 忽略Model中为null的属性
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;      // 设置本地时间而非UTC时间
                options.SerializerSettings.Converters.Add(new StringEnumConverter());              // 添加Enum转string
            })
            .AddFluentValidation(config =>
             {
                 config.RegisterValidatorsFromAssemblyContaining(typeof(UserRegisterVoValidator)); // 程序集方式添加验证
                 config.DisableDataAnnotationsValidation = true;                                   // 是否与MvcValidation共存
             });

            services.AddEndpointsApiExplorer();

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //支持编码大全 例如:支持 System.Text.Encoding.GetEncoding("GB2312")  System.Text.Encoding.GetEncoding("GB18030") 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
