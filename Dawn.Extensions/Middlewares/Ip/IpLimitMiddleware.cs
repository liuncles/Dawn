using AspNetCoreRateLimit;
using log4net;
using Microsoft.AspNetCore.Builder;

namespace Dawn.Extensions.Middlewares
{
    /// <summary>
    /// ip 限流
    /// </summary>
    public static class IpLimitMiddleware
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(IpLimitMiddleware));
        public static void UseIpLimitMiddle(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            try
            {
                if (AppSettings.App("Middleware", "IpRateLimit", "Enabled").ObjToBool())
                {
                    app.UseIpRateLimiting();
                }
            }
            catch (Exception e)
            {
                Log.Error($"Error occured limiting ip rate.\n{e.Message}");
                throw;
            }
        }
    }
}
