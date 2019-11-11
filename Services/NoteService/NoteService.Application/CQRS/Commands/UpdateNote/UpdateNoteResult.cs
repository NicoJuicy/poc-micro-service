using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.UpdateNote
{
    public class UpdateNoteResult
    {
        public Guid NoteId { get; set; }
    }
}
