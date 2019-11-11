using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Infrastructure.MessageBroker.Abstractions
{
    public interface IMessageBroker
    {
        void Subscribe<T, TH>()
            where T : IIntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        //void SubscribeDynamic<TH>(string eventName)
        //    where TH : IDynamicIntegrationEventHandler;

        //void UnsubscribeDynamic<TH>(string eventName)
        //    where TH : IDynamicIntegrationEventHandler;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IIntegrationEvent;

        void Publish(IIntegrationEvent @event);
        Task PublishAsync(IIntegrationEvent @event);

    }
}
