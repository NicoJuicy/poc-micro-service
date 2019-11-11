using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerService.Application.Events
{
    public class SchedulerUpdated : BaseIntegrationEvent, IIntegrationEvent
    {
        public SchedulerUpdated(string tenantId) : base(tenantId)
        {

        }
    }
    }
