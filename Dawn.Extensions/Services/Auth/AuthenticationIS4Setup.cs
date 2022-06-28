using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Dawn.Extensions.Services
{
    /// <summary>
    /// IS4权限 认证服务
    /// </summary>
    public static class AuthenticationIS4Setup
    {
        public static void AddAuthenticationIS4Setup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 添加Identityserver4认证
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = nameof(ApiResultHandler);
                o.DefaultForbidScheme = nameof(ApiResultHandler);
            })
            .AddJwtBearer(options =>
            {
                options.Authority = AppSettings.App(new string[] { "Startup", "IdentityServer4", "AuthorizationUrl" });
                options.RequireHttpsMetadata = false;
                options.Audience = AppSettings.App(new string[] { "Startup", "IdentityServer4", "ApiName" });
            })
            .AddScheme<AuthenticationSchemeOptions, ApiResultHandler>(nameof(ApiResultHandler), o => { });
        }
    }
}
