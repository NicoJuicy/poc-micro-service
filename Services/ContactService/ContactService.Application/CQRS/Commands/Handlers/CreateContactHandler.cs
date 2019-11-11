using ContactService.Infrastructure.Repositories;
using MediatR;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactService.Application.CQRS.Commands.Handlers
{
    public class CreateContactHandler : AsyncRequestHandler<Commands.CreateContact>
    {
        public CreateContactHandler(IDataStore dataStore, IEventBus eventBus) 
        {
            this.dataStore = dataStore; 
            this.eventBus = eventBus;
        }
        private readonly IDataStore dataStore;
        private readonly IEventBus eventBus;

        protected override async Task Handle(Commands.CreateContact request, CancellationToken cancellationToken)
        {

            Guid ContactId = request.Contact.Id == Guid.Empty ? Guid.NewGuid() : request.Contact.Id; // Guid should not be returned from the store. A command shouldn't return values || request.Contact.Id,

            if (string.IsNullOrEmpty(request.Contact.FirstName) && string.IsNullOrEmpty(request.Contact.LastName))
            {
                throw new Exceptions.ContactNameIsEmptyException(ContactId, request.Contact.FirstName, request.Contact.LastName);
            }

            var contact = new Core.Entities.Contact(
                id: ContactId,
                firstName: request.Contact.FirstName,
                lastName: request.Contact.LastName,
                email: request.Contact.Email,
                phone: request.Contact.Phone
            );

            dataStore.Contacts.AddContact(contact);
            await dataStore.CommitChanges();

            eventBus.Publish(new Events.ContactCreated("TenantId", contact.Id));

        }
    }
}
