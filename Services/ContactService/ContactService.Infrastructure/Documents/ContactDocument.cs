using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Infrastructure.Documents
{
    public class ContactDocument
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public ComplexTypes.Address Address { get; set; }

        public string Phone { get; set; }

        public IEnumerable<Guid> Notes { get; set; } 
        public IEnumerable<Guid> Tags { get; set; }
    }
}
