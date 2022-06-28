var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
var configuration = builder.Configuration;
ServicesConfigure.Configure(builder.Services, configuration, env);
ContainerConfigure.Configure(builder);
AppConfigure.Configure(builder.Build(), builder.Services, configuration, env);