using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Commands
{
    public class DeleteContact : IRequest
    {

        public Guid ContactId { get; set; }
    }
}
