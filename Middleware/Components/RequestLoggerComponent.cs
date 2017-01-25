using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Middleware.Components
{
    public class RequestLoggerComponent
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly string _name;
        private readonly DateTime _date;


        public RequestLoggerComponent(RequestDelegate next, ILoggerFactory loggerFactory, string name, DateTime date) 
        {
            if(next == null)
            {
                throw new ArgumentNullException("Next middleware delegate");
            }

            if(loggerFactory == null)
            {
                throw new ArgumentNullException("Logger factory");
            }

            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggerComponent>();
            _name = name;
            _date = date;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Handling request: {context.Request.Path}\t{_name}\t{_date}");
            await _next.Invoke(context);
            _logger.LogInformation("Finished handling request.");
        }
    }
}
