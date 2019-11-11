using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.Events
{

    public class NoteDeleted : BaseIntegrationEvent, IIntegrationEvent
    {
        public Guid NoteId { get; }

        public NoteDeleted(string tenantId, Guid noteId) : base(tenantId)
        {
            NoteId = noteId;
        }
    }
}
