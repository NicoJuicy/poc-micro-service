using ContactService.Core.Entities;
using MicroService.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Core.Events
{
    public class ContactAddressChanged : IDomainEvent
    {
        public Contact Contact { get; }

        public ContactAddressChanged(Contact contact)
        {
            Contact = contact;
        }

    }
}
