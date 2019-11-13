
//using MicroService.WebApi.Middleware;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MicroService.WebApi.Strategy
//{
    
//    public class TenantFromRequestHeaderStrategy : ITenantStrategy
//    {
//        public string TenantRequestHeader { get; }
//        private IHttpContextAccessor HttpContextAccessor { get; }
//        public TenantFromRequestHeaderStrategy()//IHttpContextAccessor httpContextAccessor)// string tenantRequestHeader = "X-TenantId")
//        {
//            TenantRequestHeader = "X-TenantId";// tenantRequestHeader;
//        //    HttpContextAccessor = httpContextAccessor;

//        }

//        public string GetTenantId()
//        {
//            string tenantValue = "";

//            Microsoft.Extensions.Primitives.StringValues values;

//            HttpContextAccessor.HttpContext.Request.Headers.TryGetValue(TenantRequestHeader, out values);

//            if(values.Count() > 0)
//            {
//                tenantValue = values.FirstOrDefault();
//            }

//            return tenantValue;
//        }

      
//    }
//}
