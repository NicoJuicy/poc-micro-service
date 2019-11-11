using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerService.Application.Events
{
    public class SchedulerRemoved : BaseIntegrationEvent, IIntegrationEvent
    {
        public SchedulerRemoved(string tenantId) : base(tenantId)
        {

        }
    
    }
}
