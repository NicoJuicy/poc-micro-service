using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Core.Entities
{
    public class Note
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public DateTimeOffset On { get; set; }
    }
}
