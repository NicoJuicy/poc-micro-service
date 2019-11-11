using ContactService.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.CQRS.Commands
{
    public class UpdateContact : IRequest
    {
        public DetailedContactDTO Contact { get; set; }
    }
}
