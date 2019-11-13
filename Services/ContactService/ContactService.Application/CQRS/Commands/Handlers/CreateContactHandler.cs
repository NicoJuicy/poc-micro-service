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
    public class CreateContactHandler : IRequestHandler<Commands.CreateContact, CreateContactResult>
    {
        public CreateContactHandler(IDataStore dataStore, IEventBus eventBus) 
        {
            this.dataStore = dataStore; 
            this.eventBus = eventBus;
        }
        private readonly IDataStore dataStore;
        private readonly IEventBus eventBus;

       

        public async Task<CreateContactResult> Handle(CreateContact request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FirstName) && string.IsNullOrEmpty(request.LastName))
            {
                throw new Exceptions.ContactNameIsEmptyException(request.ContactId, request.FirstName, request.LastName);
            }

            var contact = new Core.Entities.Contact(
                id: request.ContactId,
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                phone: request.Phone
            );

            dataStore.Contacts.AddContact(contact);
            await dataStore.CommitChanges();

            eventBus.Publish(new Events.ContactCreated("TenantId", contact.Id));

            return new CreateContactResult(contact.Id);
        }
    }
}
