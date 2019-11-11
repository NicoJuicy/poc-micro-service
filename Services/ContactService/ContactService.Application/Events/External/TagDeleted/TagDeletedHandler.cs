using ContactService.Application.CQRS.Queries;
using ContactService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactService.Application.Events.External.TagDeleted
{
    public class TagDeletedHandler : MediatR.INotificationHandler<TagDeleted>
    {
        private IMediator _mediator { get; }
        public TagDeletedHandler(IMediator mediatR)
        {
            _mediator = mediatR;
        }


        public TagDeletedHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        private readonly IDataStore dataStore;

        public async Task Handle(TagDeleted notification, CancellationToken cancellationToken)
        {
            //var contact = await dataStore.Contacts.GetContactAsync(notification.ContactId);
            //contact.DeleteTag(notification.TagId);

            dataStore.Contacts.DeleteContactTag(notification.ContactId, notification.TagId);

            await dataStore.CommitChanges();
            _mediator.Publish(new ContactUpdated(notification.TenantId,  notification.ContactId));


        }
    }
}
