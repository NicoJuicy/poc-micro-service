using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleCRM.Infrastructure.MessageBroker.Events
{
    public abstract class BaseIntegrationEvent : IIntegrationEvent
    {
        public BaseIntegrationEvent()
        {
            if(CorrelationId == Guid.Empty) CorrelationId = Guid.NewGuid();

            EventId = Guid.NewGuid();

            EventOn = DateTime.UtcNow;

            var method = new StackTrace().GetFrame(2).GetMethod();

            Sender = new SenderInformation()
            {
                Assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                Method = method.Name,
                Namespace = method.ReflectedType?.Namespace
            };
        }
        public BaseIntegrationEvent(string tenantId) : this()
        {
            TenantId = tenantId;
        }

        public BaseIntegrationEvent(Guid correlationId, string tenantId) : this(tenantId)
        {
            this.CorrelationId = correlationId;
        }

        public string TenantId { get; set; }
        public Guid CorrelationId { get; set; }
        public Guid EventId { get; }
        public DateTime EventOn { get; }
        public SenderInformation Sender { get; }

        /// <summary>
        /// Usefull for tracking/logging the correct tenantId and CorrelationId
        /// </summary>
        /// <param name="event"></param>
        public void FromPreviousEvent(IEvent @event)
        {
            TenantId = @event.TenantId();
            CorrelationId = @event.CorrelationId();
        }

        Guid IEvent.CorrelationId()
        {
            return CorrelationId;
        }

        Guid IEvent.EventId()
        {
            return EventId;
        }

        /// <summary>
        /// Describe the event that is taking place.
        /// </summary>
        /// <returns></returns>
        //public abstract override string ToString();

        string IEvent.TenantId()
        {
            return TenantId;
        }
    }

    public class SenderInformation
    {
        public SenderInformation()
        {

        }
        public string Assembly { get; set; }
        public string Method { get; set; }
        public string Namespace { get; set; }
    }
}
