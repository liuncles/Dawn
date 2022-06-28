var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
ServicesConfigure.Configure(builder.Services, env);
ContainerConfigure.Configure(builder);
AppConfigure.Configure(builder.Build());
