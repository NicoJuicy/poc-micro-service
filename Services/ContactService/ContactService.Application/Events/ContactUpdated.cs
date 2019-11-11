using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Events
{
    public class ContactUpdated : BaseIntegrationEvent, IIntegrationEvent
    {
        public Guid ContactId { get; }
        public ContactUpdated(string tenantId, Guid contactId) : base(tenantId)
        {
            ContactId = contactId;
        }
    }
}
