using MediatR;
using ContactService.Core.Repositories;
using ContactService.Infrastructure.Repositories;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using ContactService.Application.Events;
using ContactService.Application.Exceptions;

namespace ContactService.Application.CQRS.Commands.Handlers
{
    //https://lostechies.com/jimmybogard/2015/05/05/cqrs-with-mediatr-and-automapper/
    public class DeleteContactHandler : AsyncRequestHandler<Commands.DeleteContact>
    {
        public DeleteContactHandler(IDataStore dataStore, IEventBus eventBus)
        {
            this.dataStore = dataStore;
            this.eventBus = eventBus;
        }
        private readonly IDataStore dataStore;
        private readonly IEventBus eventBus;


        protected override async Task Handle(DeleteContact request, CancellationToken cancellationToken)
        {
            var contact = await dataStore.Contacts.GetContactAsync(request.ContactId);

            if (contact is null)
            {
                throw new ContactNotFoundException(request.ContactId);
            }

            dataStore.Contacts.DeleteContact(contact);
            await dataStore.CommitChanges();

            eventBus.Publish(new ContactDeleted("TenantId", contact.Id));
        }
    }
}
