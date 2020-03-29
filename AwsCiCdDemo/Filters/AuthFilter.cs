using AwsCiCdDemo.Services;
using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace AwsCiCdDemo.Filters
{
    public class AuthFilter : ActionFilterAttribute, IActionFilter
    {
        private AuthService service;

        public AuthFilter()
        {
            this.service = AuthService.Instance;
        }

        override public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!service.isAuthenticated(context.HttpContext.Request) && context.HttpContext.Request.Url.AbsolutePath != "/login")
            {
                // redirect to login
                Debug.WriteLine("Not authenticated. Redirecting to login.");
                context.Result = new RedirectResult("/login");
            }
        }
    }
}