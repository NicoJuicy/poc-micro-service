//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace SimpleCRM.Infrastructure.MessageBroker.Events
//{
//    //Taken from EventSourcing.NetCore
//    public class MediatREventBus : IEventBus
//    {
//        private readonly IMediator _mediator;

//        public MediatREventBus(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        public bool IsConnected()
//        {
//            return true;
//        }

//        public async Task Publish<TEvent>(params TEvent[] events) where TEvent : class,IEvent
//        {
//            foreach (var @event in events)
//            {
//                await _mediator.Publish(@event);
//            }
//        }
//    }
//}
