using ContactService.Infrastructure.Repositories;
using MediatR;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactService.Application.CQRS.Commands.Handlers
{
    public class UpdateContactHandler : AsyncRequestHandler<Commands.UpdateContact>
    {
        public UpdateContactHandler(IDataStore dataStore, IEventBus eventBus) 
        {
            this.dataStore = dataStore;
            this.eventBus = eventBus;
        }
        private readonly IDataStore dataStore;
        private readonly IEventBus eventBus;


        protected override async Task Handle(Commands.UpdateContact request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.FirstName) && string.IsNullOrEmpty(request.LastName))
            {
                throw new Exceptions.ContactNameIsEmptyException(request.ContactId, request.FirstName, request.LastName);
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                if (!new EmailAddressAttribute().IsValid(request.Email))
                    throw new Exceptions.ContactEmailIsNotValidException(request.ContactId, request.Email);
            }

            var contact = new Core.Entities.Contact(
                id: request.ContactId,
                firstName   : request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                phone: request.Phone
                );
            

            dataStore.Contacts.UpdateContact(contact);
            await dataStore.CommitChanges();

            eventBus.Publish(new Events.ContactDeleted("TenantId", contact.Id));

        }
    }
}
