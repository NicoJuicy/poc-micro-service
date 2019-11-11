using MediatR;
using NoteService.Application.CQRS.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Queries.GetNotes
{
    public class GetNotesQuery : IRequest<IReadOnlyList<NoteDto>>
    {
    }
}
