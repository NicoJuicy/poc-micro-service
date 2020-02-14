using MicroService.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Exceptions
{
    public abstract class ContactDomainException : ExceptionBase
    {
        public ContactDomainException(string? message) : base(message)
        {

        }

       // public abstract string Code { get; set; }
    }
}
