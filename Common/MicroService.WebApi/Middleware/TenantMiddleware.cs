using MicroService.WebApi.Strategy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.WebApi.Middleware
{
    
    public interface ITenantMiddleWare
    {
        string GetTenantId();
    }
    public class TenantMiddleware : ITenantMiddleWare
    {

        string TenantId { get; }

        public TenantMiddleware(IHttpContextAccessor httpContextAccessor, ITenantStrategy strategy)
        {
            strategy.GetTenantId(httpContextAccessor);
        }

        public string GetTenantId()
        {
            return TenantId;
        }
    }
}
