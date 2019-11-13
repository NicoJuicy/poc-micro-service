using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Queries
{

    public class GetContactById : IRequest<ContactResult>
    {
        public Guid ContactId { get; set; }
    }
}
