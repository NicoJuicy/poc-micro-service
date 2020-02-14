using MicroService.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Exceptions
{
    public class ContactNotFoundException : ContactDomainException
    {
        public ContactNotFoundException(Guid id) : base(
            $"Contact for {id} could not be found")
        {

        }
        public override string Code => "contact_not_found";
    }
}
