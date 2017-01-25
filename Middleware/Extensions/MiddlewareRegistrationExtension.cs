using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Middleware.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public static class MiddlewareRegistrationExtension
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app, ILoggerFactory loggerFactory, string name, DateTime date)
        {
            return app.UseMiddleware<RequestLoggerComponent>(loggerFactory, name, date);
        }

        public static IApplicationBuilder UseTerminalMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TerminateComponent>();
        }
    }
}
