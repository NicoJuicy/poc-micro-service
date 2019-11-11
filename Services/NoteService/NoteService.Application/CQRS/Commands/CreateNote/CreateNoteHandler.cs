using MediatR;
using NoteService.Application.Events;
using NoteService.Core.Repositories;
using NoteService.Infrastructure.Repositories;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NoteService.Application.CQRS.Commands.CreateNote
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, CreateNoteResult>
    {

        public CreateNoteHandler(IDataStore dataStore, IEventBus eventBus) 
        {
            this.dataStore = dataStore;
            this.eventBus = eventBus;
        }
        private readonly IDataStore dataStore;
        private readonly IEventBus eventBus;

        public async Task<CreateNoteResult> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {

            Guid NoteId = request.Note.Id.HasValue ? request.Note.Id.Value : Guid.NewGuid(); // Guid should not be returned from the store. A command shouldn't return values || request.Note.Id,

            if (string.IsNullOrEmpty(request.Note.Value))
            {
                throw new Exceptions.NoteIsEmptyException(NoteId);//request.Note.Id);
            }

            var note = new Core.Entities.Note()
            {
                Id = NoteId,
                On = System.DateTime.UtcNow,
                Value = request.Note.Value
            };

            dataStore.Notes.AddNote(note);
            await dataStore.CommitChanges();

            eventBus.Publish(new NoteCreated("TenantId",NoteId, note.Value));

            return new CreateNoteResult()
            {
                NoteId = NoteId
            };
        }
    }
}
