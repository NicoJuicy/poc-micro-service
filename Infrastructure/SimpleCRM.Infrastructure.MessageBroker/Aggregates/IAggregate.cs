using System;

namespace SimpleCRM.Infrastructure.MessageBroker.Aggregates
{
    public interface IAggregate
    {
        Guid Id { get; }
    }
}
