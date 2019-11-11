using ContactService.Application.DTO;
using ContactService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactService.Application.CQRS.Queries
{

    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, DetailedContactDTO>
    {
        public GetContactByIdHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        private readonly IDataStore dataStore;

        public async Task<DetailedContactDTO> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await dataStore.Contacts.GetContactAsync(request.ContactId);

            return result != null ?  new DetailedContactDTO
            {
                Id = result.Id,
                Email = result.Email,
                FirstName= result.FirstName,
                LastName = result.LastName,
                Notes = result.Notes,
                Tags = result.Tags
            } : null;
        }
    }
}
