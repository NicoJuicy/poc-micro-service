using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Events
{
    public class ContactCreated : BaseIntegrationEvent, IIntegrationEvent
    {
        public Guid ContactId { get; }

        
        public ContactCreated(Guid contactId) : base()
        {
            ContactId = contactId;
        }

        public ContactCreated(string tenantId, Guid contactId) : base(tenantId) 
        {
            ContactId = contactId;
        }
    }
}
