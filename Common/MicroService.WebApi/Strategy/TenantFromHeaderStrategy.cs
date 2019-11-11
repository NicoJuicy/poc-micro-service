
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroService.WebApi.Strategy
{
    public interface ITenantStrategy
    {
        string GetTenantId(IHttpContextAccessor httpContextAccessor);
    }
    public class TenantFromRequestHeaderStrategy : ITenantStrategy
    {
        public string TenantRequestHeader { get; }
        public TenantFromRequestHeaderStrategy(string tenantRequestHeader = "X-TenantId")
        {
            TenantRequestHeader = tenantRequestHeader;
        }

        public string GetTenantId(IHttpContextAccessor httpContextAccessor)
        {
            string tenantValue = "";

            Microsoft.Extensions.Primitives.StringValues values;

            httpContextAccessor.HttpContext.Request.Headers.TryGetValue(TenantRequestHeader, out values);

            if(values.Count() > 0)
            {
                tenantValue = values.FirstOrDefault();
            }

            return tenantValue;
        }
    }
}
