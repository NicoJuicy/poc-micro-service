using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Commands
{
    public class CreateContactResult
    {
        public CreateContactResult(Guid contactId)
        {
            ContactId = contactId;
        }
        public Guid ContactId { get; }
    }
}
