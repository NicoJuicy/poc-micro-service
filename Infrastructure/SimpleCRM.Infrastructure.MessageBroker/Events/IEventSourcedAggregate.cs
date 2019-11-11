using SimpleCRM.Infrastructure.MessageBroker.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.Infrastructure.MessageBroker.Events
{
    public interface IEventSourcedAggregate : IAggregate
    {
        Queue<IEvent> PendingEvents { get; }
    }
}
