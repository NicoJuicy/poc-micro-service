using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;


namespace NoteService.Application.Events
{
    public class NoteCreated : BaseIntegrationEvent, IIntegrationEvent
    {

        public NoteCreated(string tenantId, Guid noteId, string value) : base(tenantId)
        {
            NoteId = noteId;
            Value = value;
        }

        public Guid NoteId { get; }
        public string Value { get; }

    }
}
