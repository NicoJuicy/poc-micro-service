using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Queries
{
    public class ContactResult
    {
        public ContactResult(Guid contactId, string firstName, string lastName, string phone, string email, IEnumerable<Guid> tags, IEnumerable<Guid> notes)
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Tags = tags;
            Notes = notes;
        }
        public Guid ContactId { get; }

        public string FirstName { get; }
        public string LastName { get; }

        public string Phone { get; }

        public string Email { get; }

        public IEnumerable<Guid> Tags { get; set; }
        public IEnumerable<Guid> Notes{ get; set; }
    }
}
