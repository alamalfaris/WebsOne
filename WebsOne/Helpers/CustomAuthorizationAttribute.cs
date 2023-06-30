using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebsOne.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string user = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(user))
            {
                RedirectToLogin(context);
            }
        }

        private void RedirectToLogin(AuthorizationFilterContext context)
        {
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "Login", action = "Index" }));
        }
    }
}
