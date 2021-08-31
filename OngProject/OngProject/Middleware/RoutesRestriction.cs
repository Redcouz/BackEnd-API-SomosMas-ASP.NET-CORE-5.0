using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Middleware
{
    public class RoutesRestriction
    {
        private readonly RequestDelegate _next;
        public RoutesRestriction(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            List<string> methods = new List<string>();
            methods.Add("put");
            methods.Add("post");
            methods.Add("patch");
            methods.Add("delete");

            var method = context.Request.Method;

            List<string> paths = new List<string>();
            paths.Add("/activites");
            paths.Add("/categories");
            paths.Add("/categories/{id}");
            paths.Add("/comments");
            paths.Add("/comments/{id_post}/comments");
            paths.Add("/comments/{id}");
            paths.Add("/comments/{id}");
            paths.Add("/contacts");
            paths.Add("/members");
            paths.Add("/members/{id}");
            paths.Add("/news");
            paths.Add("/news/{id}");
            paths.Add("/organizations");
            paths.Add("/organizations/public/{id}");
            paths.Add("/role");
            paths.Add("/sendemail/{email}");
            paths.Add("/slides");
            paths.Add("/slides/{id}");
            paths.Add("/testimonials");
            paths.Add("/testimonials/{id}");
            paths.Add("/users");
            paths.Add("/users/{id}");
            paths.Add("/auth/login");
            paths.Add("/auth/register");
            paths.Add("/auth/me");

            string path = context.Request.Path;

            if (methods.Contains(method.ToLower()) && paths.Contains(path.ToLower()))
            {
                if (!context.User.IsInRole("Admin"))
                {
                    context.Response.StatusCode = 401;
                }
            }
            await _next.Invoke(context);
        }
    }
}
