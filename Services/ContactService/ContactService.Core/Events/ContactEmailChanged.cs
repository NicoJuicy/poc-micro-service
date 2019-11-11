using ContactService.Core.Entities;
using MicroService.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Core.Events
{
    public class ContactEmailChanged : IDomainEvent
    {
        public Contact Contact{ get; }
        public ContactEmailChanged(Contact contact)
        {
            Contact = contact;
        }
    }
}
