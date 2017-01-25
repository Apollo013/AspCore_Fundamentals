using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Components
{
    public class TerminateComponent
    {
        private readonly RequestDelegate _next;

        public TerminateComponent(RequestDelegate next)
        {
            if (next == null)
            {
                throw new ArgumentNullException("Next middleware delegate");
            }
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("This will terminate future calls in the pipeline");
        }
    }
}
