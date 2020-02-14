using MicroService.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.Exceptions
{

    public abstract class NoteDomainException : ExceptionBase
    {
        public NoteDomainException(string? message) : base(message)
        {

        }

        // public abstract string Code { get; set; }
    }
}
