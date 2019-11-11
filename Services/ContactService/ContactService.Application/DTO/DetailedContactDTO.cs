using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.DTO
{
    public class DetailedContactDTO : ContactDTO
    {
        public IEnumerable<Guid> Notes { get; set; } = new HashSet<Guid>();
        public IEnumerable<Guid> Tags { get; set; } = new HashSet<Guid>();
    }
}
