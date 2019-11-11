using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<DeleteNoteResult>
    {
        public Guid NoteId { get; set; }
    }
}
