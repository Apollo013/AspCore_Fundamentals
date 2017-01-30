using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Hosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var urls = new List<string>() {
                "http://*:5000",
                "http://localhost:5001"
            };

            var host = new WebHostBuilder()
                .UseSetting("applicationName", "MyApp")
                .UseSetting("detailedErrors", "true")
                .UseEnvironment("Development")
                .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
                .CaptureStartupErrors(true)
                .UseWebRoot("public") // instead of wwwroot
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
