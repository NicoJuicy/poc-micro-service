using ContactService.Application.CQRS.Queries;
using ContactService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactService.Application.Events.External.NoteDeleted
{
    public class TagDeletedHandler : MediatR.INotificationHandler<NoteDeleted>
    {
        private IMediator _mediator { get; }
        public TagDeletedHandler(IMediator mediatR)
        {
            _mediator = mediatR;
        }

        //public async Task Handle(NoteCreated notification, CancellationToken cancellationToken)
        //{
        //    var Contact = await _mediator.Send(new GetContactByIdQuery() { ContactId = notification.ContactId });

        //    Contact.Notes.Add(notification.NoteId);

        //    await _mediator.Send(new UpdateContactCommand()
        //    {
        //        Contact = Contact
        //    });

        //}


        public TagDeletedHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        private readonly IDataStore dataStore;

        public async Task Handle(NoteDeleted notification, CancellationToken cancellationToken)
        {
            dataStore.Contacts.DeleteContactNote(notification.ContactId, notification.NoteId);

            await dataStore.CommitChanges();
            _mediator.Publish(new ContactUpdated("TenantId", notification.ContactId));


        }
    }
}
