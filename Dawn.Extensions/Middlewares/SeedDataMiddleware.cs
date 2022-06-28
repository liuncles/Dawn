using Dawn.Commons.Seed;
using log4net;
using Microsoft.AspNetCore.Builder;

namespace Dawn.Extensions.Middlewares
{
    /// <summary>
    /// 生成种子数据中间件服务
    /// </summary>
    public static class SeedDataMiddleware
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SeedDataMiddleware));
        public static void UseSeedDataMiddle(this IApplicationBuilder app, ApplicationDbContext appContext, string webRootPath)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            try
            {
                if (AppSettings.App("AppSettings", "SeedDBEnabled").ObjToBool() || AppSettings.App("AppSettings", "SeedDBDataEnabled").ObjToBool())
                {
                    DBSeed.SeedAsync(appContext, webRootPath).Wait();
                }
            }
            catch (Exception e)
            {
                Log.Error($"Error occured seeding the Database.\n{e.Message}");
                throw;
            }
        }
    }
}
