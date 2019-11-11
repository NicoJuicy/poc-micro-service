using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Common.CQRS
{
    public class TenantableCqrs
    {
        public TenantableCqrs(string tenantId)
        {
            TenantId = tenantId;
        }
        public string TenantId { get; set; }
    }
}
