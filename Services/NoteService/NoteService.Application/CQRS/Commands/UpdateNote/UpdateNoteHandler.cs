using MediatR;
using NoteService.Application.Events;
using NoteService.Core.Repositories;
using NoteService.Infrastructure.Repositories;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NoteService.Application.CQRS.Commands.UpdateNote
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, UpdateNoteResult>
    {
        public UpdateNoteHandler(IDataStore dataStore, IEventBus eventBus)
        {
            this.dataStore = dataStore;
            this.eventBus = eventBus;
        }
        private readonly IDataStore dataStore;
        private readonly IEventBus eventBus;

        public async Task<UpdateNoteResult> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {

         
            if (string.IsNullOrEmpty(request.Note.Value))
            {
                throw new Exceptions.NoteIsEmptyException(request.Note.Id);
            }

            var note = new Core.Entities.Note()
            {
                Id = request.Note.Id,
                On = System.DateTime.UtcNow,
                Value = request.Note.Value
            };

            dataStore.Notes.UpdateNote(note);
            await dataStore.CommitChanges();

            eventBus.Publish(new NoteUpdated("TenantId", note.Id, note.Value));

            return new UpdateNoteResult()
            {
                NoteId = note.Id
            };
        }
    }
}
