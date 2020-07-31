using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        List<string> NaoRedirecionar = new List<string> { "/login", "/home/privacy" };

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (NaoRedirecionar.Contains(httpContext.Request.Path.ToString().ToLower()))
            {
                await _next(httpContext);
                return;
            }

            if (string.IsNullOrEmpty(httpContext.Session.GetString("logado")))
            {
                httpContext.Response.Redirect("/login");
            }
            await _next(httpContext);
        }
    }
}
