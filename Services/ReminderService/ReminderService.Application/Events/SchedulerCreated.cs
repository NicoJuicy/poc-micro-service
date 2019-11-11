using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerService.Application.Events
{
    public class SchedulerCreated : BaseIntegrationEvent, IIntegrationEvent
    {
        public SchedulerCreated(string tenantId) : base(tenantId)
        {

        }
    }
}
