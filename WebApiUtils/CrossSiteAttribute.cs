using System;
using System.Web.Http.Filters;

namespace WebApiUtils
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple = false)]
    public class CrossSiteAttribute: ActionFilterAttribute
    {
        public bool Enable { get; set; } = true;
        private const string Origin = "Origin";
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        private const string OriginHeaderdefault = "*";
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (Enable)
            {
                actionExecutedContext.Response.Headers.Add(AccessControlAllowOrigin, OriginHeaderdefault);
            }
           
        }
    }
}
