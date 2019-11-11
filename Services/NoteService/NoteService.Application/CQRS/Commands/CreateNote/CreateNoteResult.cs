using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.CreateNote
{
    public class CreateNoteResult 
    {

        public Guid NoteId { get; set; }
    }
}
