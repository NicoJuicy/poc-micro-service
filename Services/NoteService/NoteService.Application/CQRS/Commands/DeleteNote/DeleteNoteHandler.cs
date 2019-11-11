using MediatR;
using NoteService.Core.Repositories;
using NoteService.Infrastructure.Repositories;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NoteService.Application.CQRS.Commands.DeleteNote
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, DeleteNoteResult>
    {
        public DeleteNoteHandler(IDataStore dataStore, IEventBus eventBus)
        {
            this.dataStore = dataStore;
            this.eventBus = eventBus;
        }
        private readonly IDataStore dataStore;
        private readonly IEventBus eventBus;


        public async Task<DeleteNoteResult> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Core.Entities.Note()
            {
                Id = request.NoteId
            };

            dataStore.Notes.DeleteNote(note);

            await dataStore.CommitChanges();

            eventBus.Publish(new Events.NoteDeleted(note.Id));


            return new DeleteNoteResult()
            {

                NoteId = request.NoteId
            };
        }
    }
}
