using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Project1.Filters
{
    public class BasicAuthAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var req = context.HttpContext.Request;

            if (!req.Headers.ContainsKey("Authorization"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var header = req.Headers["Authorization"].ToString();
            if (!header.StartsWith("Basic "))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var encoded = header.Substring("Basic ".Length).Trim();
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
            var parts = decoded.Split(':');

            var username = parts[0];
            var password = parts[1];

            // Dummy check (Replace with SQL check)
            if (username != "admin1" || password != "xxx")
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
