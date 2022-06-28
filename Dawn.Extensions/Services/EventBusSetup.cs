using Autofac;
using Dawn.EventBus.EventBus;
using Dawn.EventBus.EventBusKafka;
using Dawn.EventBus.EventBusSubscriptions;
using Dawn.EventBus.RabbitMQPersistent;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Dawn.Extensions.Services
{
    /// <summary>
    /// EventBus 事件总线服务
    /// </summary>
    public static class EventBusSetup
    {
        public static void AddEventBusSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (AppSettings.App(new string[] { "EventBus", "Enabled" }).ObjToBool())
            {
                var subscriptionClientName = AppSettings.App(new string[] { "EventBus", "SubscriptionClientName" });

                services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
                //services.AddTransient<BlogQueryIntegrationEventHandler>();

                if (AppSettings.App(new string[] { "RabbitMQ", "Enabled" }).ObjToBool())
                {
                    services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                    {
                        var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                        var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                        var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                        var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                        var retryCount = 5;
                        if (!string.IsNullOrEmpty(AppSettings.App(new string[] { "RabbitMQ", "RetryCount" })))
                        {
                            retryCount = int.Parse(AppSettings.App(new string[] { "RabbitMQ", "RetryCount" }));
                        }

                        return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
                    });
                }
                if (AppSettings.App(new string[] { "Kafka", "Enabled" }).ObjToBool())
                {
                    services.AddHostedService<KafkaConsumerHostService>();
                    services.AddSingleton<IEventBus, EventBusKafka>();
                }
            }
        }

        /// <summary>
        /// 事件总线，订阅服务
        /// </summary>
        /// <param name="app"></param>
        //public static void ConfigureEventBus(this IApplicationBuilder app)
        //{
        //    if (AppSettings.App(new string[] { "EventBus", "Enabled" }).ObjToBool())
        //    {
        //        var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
        //        eventBus.Subscribe<BlogQueryIntegrationEvent, BlogQueryIntegrationEventHandler>();
        //    }
        //}
    }
}
