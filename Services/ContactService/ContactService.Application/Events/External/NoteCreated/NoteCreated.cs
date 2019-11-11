using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Events.External.NoteCreated
{
    public class NoteCreated : BaseIntegrationEvent, IIntegrationEvent
    {

        public NoteCreated(Guid noteId, Guid contactId)
        {
            NoteId = noteId;
            ContactId = contactId;
        }

        public Guid ContactId { get;  }
        public Guid NoteId { get;  }

    }
}
