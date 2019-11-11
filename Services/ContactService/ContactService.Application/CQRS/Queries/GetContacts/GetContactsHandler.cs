using ContactService.Application.DTO;
using ContactService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ContactService.Application.CQRS.Queries.GetContacts
{


    public class GetContactsHandler : IRequestHandler<GetContactsQuery, IReadOnlyList<DetailedContactDTO>>
    {
        public GetContactsHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        private readonly IDataStore dataStore;

        public async Task<IReadOnlyList<DetailedContactDTO>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var result = await dataStore.Contacts.GetContactsAsync();

            
            return result != null ? result.Select(dl => new DetailedContactDTO
            {
                Id = dl.Id,
                Email = dl.Email,
                FirstName = dl.FirstName,
                LastName = dl.LastName,
                Notes = dl.Notes,
                Tags = dl.Tags
            }).ToList() : null;
        }

    }
}
