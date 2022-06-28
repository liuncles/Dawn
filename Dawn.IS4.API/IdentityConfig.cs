namespace Dawn.IS4.API
{
    /// <summary>
    /// IdentityServer4配置
    /// </summary>
    public class IdentityConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Dawn.IS4.API"),
                new ApiScope("Dawn.API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("Dawn.IS4.API","IS4服务")
                {
                    ApiSecrets ={ new Secret("Dawn.IS4.API secret".Sha256()) },
                    Scopes = { "Dawn.IS4.API" }
                },
                new ApiResource("Dawn.API","Dawn服务")
                {
                    ApiSecrets ={ new Secret("Dawn.API secret".Sha256()) },
                    Scopes = { "Dawn.API" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "web client",
                    ClientName = "web Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = new [] { new Secret("web client secret".Sha256()) },

                    RedirectUris = { "http://localhost:5000/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:5000/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5000/signout-callback-oidc" },
                    
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "is4_api","dawn_api"
                    },
                    AllowAccessTokensViaBrowser = true,

                    RequireConsent = true,              //是否显示同意界面
                    AllowRememberConsent = false,       //是否记住同意选项
                }
            };
    }
}
