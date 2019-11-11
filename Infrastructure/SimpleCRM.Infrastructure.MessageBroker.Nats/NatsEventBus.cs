using Microsoft.Extensions.DependencyInjection;
using MyNatsClient;
using MyNatsClient.Encodings.Json;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Infrastructure.MessageBroker.Nats
{

    public class NatsEventBus<TEvent> : IEventBus
    {

        private const string EVENT_SUFFIX = "Event_";
        private readonly NatsClient client;


        public NatsEventBus(string[] hosts)
        {
            var _hosts = hosts.ToList().Select(dl => new Host(dl, 4222)).ToArray();

            var connectionInfo = new ConnectionInfo(
               //Hosts to use. When connecting, will randomize the list
               //and try to connect. First successful will be used.
               _hosts);

            client = new NatsClient(connectionInfo);
            client.Connect();
        }


       // [Obsolete(error:true,message:"Yeah, this won't work yet")]
       //public async Task ix(this IServiceCollection sc)
       // {
       //     var eventName = "T";//TEvent.GetType().Name.Replace(EVENT_SUFFIX, "");
       //    // sc.

       //     await client.SubAsync(eventName, stream => stream.Subscribe(msg => {
       //         // msg.FromJson()
       //         msg.FromJson(eventName);
       //        //Console.WriteLine($"Clock ticked. Tick is {msg.GetPayloadAsString()}");
       //     }));

       //     //await client.SubAsync<TEvent>(eventName,msg => { 
       //     //    msg.
       //     //}
       // }

        public async Task Publish<TEvent>(params TEvent[] events) 
            where TEvent : class,IEvent
        {
            foreach (var @event in events)
            {
                var eventName = @event.GetType().Name.Replace(EVENT_SUFFIX, "");
                client.PubAsJson<TEvent>(eventName, @event);
            }
        }
    }
}
