using ContactService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactService.Application.CQRS.Queries.Handlers
{

    public class GetContactByIdHandler : IRequestHandler<GetContactById, ContactResult>
    {
        public GetContactByIdHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        private readonly IDataStore dataStore;

        public async Task<ContactResult> Handle(GetContactById request, CancellationToken cancellationToken)
        {
            var result = await dataStore.Contacts.GetContactAsync(request.ContactId);

            return result != null ?  new ContactResult(
                result.Id,
                result.FirstName,
                result.LastName,
                 result.Phone,
                   result.Email,
                  
                result.Tags,
                result.Notes) : null;
        }
    }
}
