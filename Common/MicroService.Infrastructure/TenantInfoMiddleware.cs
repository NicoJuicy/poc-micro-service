using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MicroService.Infrastructure
{
    public class TenantInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //  var tenantInfo = context.RequestServices.GetRequiredService<TenantInfo>();
            TenantInfo tenantInfo = (TenantInfo)context.RequestServices.GetService(typeof(TenantInfo));
          
            var tenantName = context.Request.Headers["X-Tenant"];

            if (string.IsNullOrEmpty(tenantName))
                tenantName = "_";

            tenantInfo.Name = tenantName;

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
