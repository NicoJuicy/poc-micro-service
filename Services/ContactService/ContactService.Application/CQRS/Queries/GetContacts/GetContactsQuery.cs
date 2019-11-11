using ContactService.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<IReadOnlyList<DetailedContactDTO>>
    {
    }
}
