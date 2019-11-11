using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<UpdateNoteResult>
    {
        public UpdateNoteDto Note { get; set; }
    }
}
