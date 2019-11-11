using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Infrastructure.ComplexTypes
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string Country { get; set; }
    }
}
