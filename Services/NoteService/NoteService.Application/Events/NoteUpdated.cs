using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.Events
{
    public class NoteUpdated : BaseIntegrationEvent, IIntegrationEvent
    {
        public Guid NoteId { get; }
        public string Value { get; }

        public NoteUpdated(string tenantId, Guid noteId, string value) : base(tenantId)
        {
            NoteId = NoteId;
            Value = value;
        }
    }
}
