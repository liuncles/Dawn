using Dawn.Extensions.Apollo;
using Dawn.Extensions.Services;
using Dawn.IS4.API.Attribute;

namespace Dawn.IS4.API
{
    public class ContainerConfigure
    {
        /// <summary>
        /// 依赖项注入容器
        /// </summary>
        /// <param name="host"></param>
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Host
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacModuleRegister());
                builder.RegisterModule<AutofacPropertityModuleReg>();
            })
            .ConfigureLogging((hostingContext, builder) =>
            {
                builder.AddFilter("System", LogLevel.Error);
                builder.AddFilter("Microsoft", LogLevel.Error);
                builder.SetMinimumLevel(LogLevel.Error);
                builder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "Log4net.config"));
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.Sources.Clear();
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                config.AddConfigurationApollo("appsettings.apollo.json");
            });
        }
    }
}
