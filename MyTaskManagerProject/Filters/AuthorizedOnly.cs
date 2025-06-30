using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyTaskManagerProject.Filters
{
    public class AuthorizedOnly : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? userId = context.HttpContext.Session.GetString("UserId");

            if (userId != null) { return; }

            context.Result = new UnauthorizedResult();
        }
    }
}
