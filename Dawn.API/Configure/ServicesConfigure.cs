namespace Dawn.API
{
    public class ServicesConfigure
    {
        /// <summary>
        /// 服务配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env"></param>
        public static void Configure(IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddSingleton(new AppSettings(env.ContentRootPath));
            //services.AddDbContext<MasterDbContext>(options =>
            //    options.UseMySql(AppSettings.App("mysql"), MySqlServerVersion.LatestSupportedServerVersion));
            services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = AppSettings.App("MySqlConn"),
                DbType = IocDbType.MySql,
                IsAutoCloseConnection = true
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
