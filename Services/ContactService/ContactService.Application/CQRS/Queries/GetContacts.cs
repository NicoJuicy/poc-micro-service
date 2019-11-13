using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Queries
{
    public class GetContacts : IRequest<IReadOnlyList<ContactResult>>
    {
    }
}
