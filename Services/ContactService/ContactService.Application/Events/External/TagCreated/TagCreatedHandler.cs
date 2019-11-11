using ContactService.Application.CQRS.Queries;
using ContactService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactService.Application.Events.External.TagCreated
{
    public class TagCreatedHandler : MediatR.INotificationHandler<TagCreated>
    {
        private IMediator _mediator { get; }
        public TagCreatedHandler(IMediator mediatR)
        {
            _mediator = mediatR;
        }


        public TagCreatedHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        private readonly IDataStore dataStore;

        public async Task Handle(TagCreated notification, CancellationToken cancellationToken)
        {
            //var contact = await dataStore.Contacts.GetContactAsync(notification.ContactId);
            //contact.AddTag(notification.TagId);

            dataStore.Contacts.AddContactTag(notification.ContactId, notification.TagId);


            await dataStore.CommitChanges();
            _mediator.Publish(new ContactUpdated(notification.TenantId, notification.ContactId));


        }
    }
}
