using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.CreateNote
{
    public class CreateNoteDto
    {
        public Guid? Id { get; set; }

        public string Value { get; set; }
    }
}
