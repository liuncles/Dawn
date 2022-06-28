namespace Dawn.API
{
    public class ContainerConfigure
    {
        /// <summary>
        /// DI容器配置
        /// </summary>
        /// <param name="builder"></param>
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());  //覆盖用于创建服务提供者的工厂
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>         //依赖注入
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;

                var servicesDllFile = Path.Combine(basePath, "Service.dll");              //需要依赖注入的项目生成的dll文件名称
                var repositoryDllFile = Path.Combine(basePath, "Repository.dll");
                var assemblysServices = Assembly.LoadFrom(servicesDllFile);
                containerBuilder.RegisterAssemblyTypes(assemblysServices)
                    .Where(x => x.FullName.EndsWith("Service"))                           //对比名称最后是否相同然后注入
                          .AsImplementedInterfaces()
                          .InstancePerDependency();
                var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
                containerBuilder.RegisterAssemblyTypes(assemblysRepository)
                    .Where(x => x.FullName.EndsWith("Repository"))
                          .AsImplementedInterfaces()
                          .InstancePerDependency();
            });
        }
    }
}
