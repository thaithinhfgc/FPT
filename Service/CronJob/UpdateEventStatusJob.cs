using Microsoft.Extensions.DependencyInjection;
using Service.Implement.EventModule;
using Service.Interface.EventModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CronJob
{
    public class UpdateEventStatusJob : CronJobService
    {
        private readonly IServiceScopeFactory ServiceScopeFactory;
        private readonly IEventService eventService;

        public UpdateEventStatusJob(IScheduleConfig<UpdateEventStatusJob> config, IServiceScopeFactory serviceScopeFactory)
        : base(config.CronExpression, config.TimeZoneInfo)
        {
            ServiceScopeFactory = serviceScopeFactory;
            eventService = (EventService)ServiceScopeFactory.CreateScope().ServiceProvider.GetService<IEventService>();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Update Event Status cron job starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            this.eventService.UpdateEventStatus();

            Console.WriteLine($"{DateTime.Now:hh:mm:ss} Update Event Status cron job is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Update Event Status cron job is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
