using Dawn.Tasks.QuartzNet;
using Quartz;
using Quartz.Spi;
using System.Reflection;

namespace Dawn.Extensions.Services
{
    /// <summary>
    /// 任务调度 启动服务
    /// </summary>
    public static class TasksSetup
    {
        public static void AddTasksSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddHostedService<Job1TimedService>();
            //services.AddHostedService<Job2TimedService>();

            services.AddSingleton<IJobFactory, JobFactory>();
            //services.AddTransient<Job_Blogs_Quartz>();                            // Job使用瞬时依赖注入
            //services.AddTransient<Job_OperateLog_Quartz>();                       // Job使用瞬时依赖注入
            services.AddSingleton<ISchedulerCenterServer, SchedulerCenterServer>();

            //任务注入
            var baseType = typeof(IJob);
            var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var referencedAssemblies = Directory.GetFiles(path, "Dawn.Tasks.dll").Select(Assembly.LoadFrom).ToArray();
            var types = referencedAssemblies
                .SelectMany(a => a.DefinedTypes)
                .Select(type => type.AsType())
                .Where(x => x != baseType && baseType.IsAssignableFrom(x)).ToArray();
            var implementTypes = types.Where(x => x.IsClass).ToArray();
            foreach (var implementType in implementTypes)
            {
                services.AddTransient(implementType);
            }
        }
    }
}
