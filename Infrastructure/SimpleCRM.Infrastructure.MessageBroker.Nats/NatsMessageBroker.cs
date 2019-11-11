//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using MyNatsClient;
//using MyNatsClient.Encodings.Json;
//using MyNatsClient.Encodings.Protobuf;
//using SimpleCRM.Infrastructure.MessageBroker.Abstractions;
//using SimpleCRM.Infrastructure.MessageBroker.Events;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Reactive;
//using System.Reactive.Linq;

//namespace SimpleCRM.Infrastructure.MessageBroker.Nats
//{
//    public class NatsMessageBroker : IMessageBroker
//    {
//        private const string INTEGRATION_EVENT_SUFIX = "IntegrationEvent_";
//        private readonly NatsClient client;
//        private readonly IServiceProvider serviceProvider;

//        public NatsMessageBroker(string[] hosts, IServiceProvider serviceProvider)
//        {
//            var _hosts = hosts.ToList().Select(dl => new Host(dl, 4222)).ToArray();

//            var connectionInfo = new ConnectionInfo(
//               //Hosts to use. When connecting, will randomize the list
//               //and try to connect. First successful will be used.
//               _hosts);

//            client = new NatsClient(connectionInfo);
//            client.Connect();

//            this.serviceProvider = serviceProvider;

//        }

//        public async Task PublishAsync(IIntegrationEvent @event)
//        {
//            var eventName = @event.GetType().Name.Replace(INTEGRATION_EVENT_SUFIX, "");
//            await client.PubAsJsonAsync(eventName, @event);
//        }

//        public void Publish(IIntegrationEvent @event)
//        {
//            var eventName = @event.GetType().Name.Replace(INTEGRATION_EVENT_SUFIX, "");
//            client.PubAsJson(eventName, @event);
//        }

//        //https://github.com/asc-lab/dotnetcore-microservices-poc/blob/297cf1060d7e4587d9c3c95be746e43cbdacb310/ChatService/Messaging/RabbitMq/RabbitEventListener.cs
//        public void Subscribe<T, TH>()
//            where T : IIntegrationEvent
//            where TH : IIntegrationEventHandler<T>
//        {
//            var eventName = typeof(T).Name.Replace(INTEGRATION_EVENT_SUFIX, "");

//            using (var scope = serviceProvider.CreateScope())
//            {
//                var internalMediatR = scope.ServiceProvider.GetRequiredService<IMediator>();
                
//                //TODO: This is probably not correct yet!
//                client.Sub(eventName, stream => stream.Subscribe(msg => internalMediatR.Publish(msg)));
//            }

//            //client.Sub(eventName;
        
         
//        }

//        //public void SubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
//        //{
//        //    throw new NotImplementedException();
//        //}

//        public void Unsubscribe<T, TH>()
//            where T : IIntegrationEvent
//            where TH : IIntegrationEventHandler<T>
//        {
//            var eventName = typeof(T).Name.Replace(INTEGRATION_EVENT_SUFIX, "");
//            //client.Unsub(eventName);
//        }

//        //public void UnsubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //private void RegisterSubscriptionClientMessageHandler()
//        //{
//        //    client.Sub()
//        //    _subscriptionClient.RegisterMessageHandler(
//        //        async (message, token) =>
//        //        {
//        //            var eventName = $"{message.Label}{INTEGRATION_EVENT_SUFIX}";
//        //            var messageData = Encoding.UTF8.GetString(message.Body);
//        //            await ProcessEvent(eventName, messageData);

//        //            // Complete the message so that it is not received again.
//        //            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
//        //        },
//        //       new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = 10, AutoComplete = false });
//        //}
//    }
//}
