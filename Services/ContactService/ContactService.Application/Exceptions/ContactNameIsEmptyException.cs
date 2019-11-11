using MicroService.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Exceptions
{
    public class ContactNameIsEmptyException : ExceptionBase
    {
        public ContactNameIsEmptyException(Guid id, string firstName, string lastName) : base(
            $"contact for {id} can not be created because the name is empty. Firstname : {firstName}, Lastname: {lastName} ")
        {

        }
        public override string Code => "contact_name_is_empty";
    }
}
