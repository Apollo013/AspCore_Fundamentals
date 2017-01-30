using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ILogger _logger;

        public ToDoController(ILoggerFactory loggerFactory)
        {
            if(loggerFactory == null)
            {
                throw new ArgumentNullException("Logger null");
            }
            _logger = loggerFactory.CreateLogger<ToDoController>();
        }

        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GET_ITEM, "Getting item {ID}", id);
            var item = new { name = "Paul" } ; // _todoRepository.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "GetById({ID}) NOT FOUND", id);
                return NotFound();
            }
            else
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, item.name);
            }
            return new ObjectResult(item);
        }

        public string Index()
        {
            return "This is a killer homepage from the Home controller!!!!";
        }
    }
}
