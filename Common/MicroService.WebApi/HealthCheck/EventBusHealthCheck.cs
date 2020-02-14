using Microsoft.Extensions.Diagnostics.HealthChecks;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.WebApi.HealthCheck
{
   

    public class EventBusHealthCheck :  IHealthCheck
    {
        private readonly IEventBus eventBus;

        public EventBusHealthCheck(IEventBus eventBus) 
        {
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (!eventBus.IsConnected())
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }

            return Task.FromResult( HealthCheckResult.Healthy());

        }
    }
}
