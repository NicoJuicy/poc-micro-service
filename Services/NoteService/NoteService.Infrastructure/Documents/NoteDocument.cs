﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Infrastructure.Documents
{
    public class NoteDocument
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public DateTimeOffset On { get; set; }


    }
}
