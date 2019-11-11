using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.Infrastructure.MessageBroker.Events
{
    public interface IEvent : INotification
    {
        string TenantId();
        Guid EventId();
        Guid CorrelationId();

        void FromPreviousEvent(IEvent @event);

        
    }

  
}
