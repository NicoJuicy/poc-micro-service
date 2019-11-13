//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace MicroService.Core.Middleware
//{
    
//    public interface ITenantMiddleWare
//    {
//        string GetTenantId();
//    }
//    public class TenantMiddleware : ITenantMiddleWare
//    {

//        string TenantId { get; }

//        public TenantMiddleware( ITenantStrategy strategy) //IHttpContextAccessor httpContextAccessor,
//        {
//            strategy.GetTenantId(); //httpcontext
//        }

//        public string GetTenantId()
//        {
//            return TenantId;
//        }
//    }

//    public interface ITenantStrategy
//    {
//        string GetTenantId();// IHttpContextAccessor httpContextAccessor);
//    }
//}
