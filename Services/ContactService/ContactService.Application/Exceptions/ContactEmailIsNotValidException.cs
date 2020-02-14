using MicroService.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Exceptions
{
    public class ContactEmailIsNotValidException : ContactDomainException
    {
        public ContactEmailIsNotValidException(Guid id, string email) : base(
          $"contact for {id} can not be created because the email is invalid. Email: {email}")
        {

        }
        public override string Code => "contact_email_is_invalid";
    }
}
