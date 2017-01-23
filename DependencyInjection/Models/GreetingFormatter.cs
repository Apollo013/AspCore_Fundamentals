using DependencyInjection.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class GreetingFormatter : IGreetingFormatter
    {
        private readonly IGreeter _greeter;

        public GreetingFormatter(IGreeter greeter)
        {
            if(greeter == null)
            {
                throw new ArgumentNullException("Greeter must be specified");
            }
            _greeter = greeter;
        }

        public string Format()
        {
            return JsonConvert.SerializeObject(new { Greeting = _greeter.SendGreeting() });
        }
    }
}
