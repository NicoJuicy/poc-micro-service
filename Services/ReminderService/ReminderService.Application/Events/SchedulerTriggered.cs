using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerService.Application.Events
{
    public class SchedulerTriggered : BaseIntegrationEvent, IIntegrationEvent
    {
        public SchedulerTriggered(string tenantId) : base(tenantId)
        {

        }
    
    }
}
