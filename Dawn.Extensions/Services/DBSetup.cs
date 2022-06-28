using Dawn.Commons.Seed;

namespace Dawn.Extensions.Services
{
    /// <summary>
    /// Db 启动服务
    /// </summary>
    public static class DBSetup
    {
        public static void AddDbSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<DBSeed>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
