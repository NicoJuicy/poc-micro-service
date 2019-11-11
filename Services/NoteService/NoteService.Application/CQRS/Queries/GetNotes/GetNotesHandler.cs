using MediatR;
using NoteService.Application.CQRS.Queries.Dtos;
using NoteService.Core.Repositories;
using NoteService.Infrastructure.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace NoteService.Application.CQRS.Queries.GetNotes
{
    public class GetNotesHandler : IRequestHandler<GetNotesQuery, IReadOnlyList<NoteDto>>
    {
        public GetNotesHandler(IDataStore dataStore) 
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        private readonly IDataStore dataStore;

        public async Task<IReadOnlyList<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var result = await dataStore.Notes.GetNotesAsync();//.(request.NoteId);

            return result != null ? result.Select(dl =>  new NoteDto
            {
                Id = dl.Id,
                On = dl.On,
                Value = dl.Value
            }).ToList() : null;
        }
    }
}
