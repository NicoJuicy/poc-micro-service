using MicroService.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.Exceptions
{
    public class NoteIsEmptyException : ExceptionBase
    {
        public NoteIsEmptyException(Guid id):base(
            $"note for {id} can not be created because the value is empty")
        {

        }
        public override string Code => "note_is_empty";
    }
}
