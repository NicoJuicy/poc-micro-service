using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Application.CQRS.Queries.Dtos
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTimeOffset On { get; set; }
    }
}
