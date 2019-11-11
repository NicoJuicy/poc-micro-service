using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Events
{
    public class ContactDeleted : BaseIntegrationEvent, IIntegrationEvent
    { 
        public Guid ContactId { get;  }
        
        public ContactDeleted(string tenantId, Guid contactId) : base(tenantId)
        {
            ContactId = contactId;
           
        }

    }
}
