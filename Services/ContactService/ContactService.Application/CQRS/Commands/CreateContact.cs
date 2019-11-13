using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Commands
{
    public class CreateContact : IRequest<CreateContactResult>
    {
        public CreateContact()
        {

        }
        public CreateContact(Guid contactId, string firstName, string lastName, string phone, string email)
        {

            ContactId = contactId == Guid.Empty ? Guid.NewGuid() : contactId; ;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }
        public Guid ContactId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

    }
}
