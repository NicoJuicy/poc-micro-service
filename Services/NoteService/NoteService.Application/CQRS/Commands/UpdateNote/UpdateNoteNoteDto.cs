using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.UpdateNote
{
    public class UpdateNoteDto
    {
        public Guid Id { get; set; }

        public string Value { get; set; }
    }
}
