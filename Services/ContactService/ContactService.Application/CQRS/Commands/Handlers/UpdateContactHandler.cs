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

            if (string.IsNullOrEmpty(request.Contact.FirstName) && string.IsNullOrEmpty(request.Contact.LastName))
            {
                throw new Exceptions.ContactNameIsEmptyException(request.Contact.Id, request.Contact.FirstName, request.Contact.LastName);
            }

            if (!string.IsNullOrEmpty(request.Contact.Email))
            {
                if (!new EmailAddressAttribute().IsValid(request.Contact.Email))
                    throw new Exceptions.ContactEmailIsNotValidException(request.Contact.Id, request.Contact.Email);
            }

            
            var contact = new Core.Entities.Contact(
                id: request.Contact.Id,
                firstName   : request.Contact.FirstName,
                lastName: request.Contact.LastName,
                email: request.Contact.Email,
                phone: request.Contact.Phone
                );
            

            dataStore.Contacts.UpdateContact(contact);
            await dataStore.CommitChanges();

            eventBus.Publish(new Events.ContactDeleted("TenantId", contact.Id));

        }
    }
}
