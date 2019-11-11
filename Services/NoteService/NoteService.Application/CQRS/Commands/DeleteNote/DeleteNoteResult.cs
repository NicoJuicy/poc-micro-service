using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.DeleteNote
{
    public class DeleteNoteResult
    {
        public Guid NoteId { get; set; }
    }
}
