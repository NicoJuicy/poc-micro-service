using MediatR;
using NoteService.Application.CQRS.Queries.Dtos;
using NoteService.Core.Repositories;
using NoteService.Infrastructure.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NoteService.Application.CQRS.Queries.GetNoteById
{
    public class GetNoteByIdHandler : IRequestHandler<GetNoteByIdQuery, NoteDto>
    {
        public GetNoteByIdHandler(IDataStore dataStore) 
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        private readonly IDataStore dataStore;

        public async Task<NoteDto> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await dataStore.Notes.GetNoteAsync(request.NoteId);

            return result != null ? new NoteDto
            {
                Id = result.Id,
                On = result.On,
                Value = result.Value
            } : null;
        }
    }
}
