using ContactService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ContactService.Application.CQRS.Queries.Handlers
{


    public class GetContactsHandler : IRequestHandler<GetContacts, IReadOnlyList<ContactResult>>
    {
        public GetContactsHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        private readonly IDataStore dataStore;

        public async Task<IReadOnlyList<ContactResult>> Handle(GetContacts request, CancellationToken cancellationToken)
        {
            var result = await dataStore.Contacts.GetContactsAsync();


            return result != null ? result
                .Select(dl =>
                new ContactResult(
                    dl.Id,
                    dl.FirstName,
                    dl.LastName,
                    dl.Phone,
                    dl.Email,
                    dl.Notes,
                    dl.Tags
                ))
                .ToList() : null;
        }

    }
}
