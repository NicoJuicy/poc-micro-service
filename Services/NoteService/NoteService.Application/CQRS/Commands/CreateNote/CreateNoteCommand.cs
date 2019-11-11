using MediatR;
using MicroService.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<CreateNoteResult>
    {
       
        public CreateNoteDto Note { get; set; }
    }
}
