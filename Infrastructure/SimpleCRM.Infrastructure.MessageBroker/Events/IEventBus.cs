using System.Threading.Tasks;


namespace SimpleCRM.Infrastructure.MessageBroker.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(params TEvent[] events) where TEvent : class,IEvent;
        bool IsConnected();


    }

    //public interface IExternalEventBus : IEventBus
    //{
    //}

    //public interface IInternalEventBus : IEventBus
    //{

    //}
}
