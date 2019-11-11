using ContactService.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Queries
{

    public class GetContactByIdQuery : IRequest<DetailedContactDTO>
    {
        public Guid ContactId { get; set; }
    }
}
