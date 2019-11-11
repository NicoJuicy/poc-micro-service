using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace TagService.Application.Events
{
    public class TagDeleted : BaseIntegrationEvent, IIntegrationEvent
    {
        public Guid TagId { get;  }

        public TagDeleted(string tenantId, Guid tagId) : base(tenantId)
        {
            TagId = tagId;
        }
    
    }
}
