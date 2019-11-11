using MediatR;
using NoteService.Application.CQRS.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Queries.GetNoteById
{
   public class GetNoteByIdQuery : IRequest<NoteDto>
    {
        public Guid NoteId { get; set; }
    }
}
