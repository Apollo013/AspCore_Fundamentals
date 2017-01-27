using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Environment
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            RegisterConfigurationManager(env);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction())
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions()
                {
                    //ExceptionHandlingPath = new PathString("/Error")
                    ExceptionHandler = context => context.Response.WriteAsync("An exception has occurred. Please contact admin@nosuchcompany.com for assistance.")
                });
            }

            app.Run(async (context) =>
            {
                string user = _configuration["DbConnection:username"];
                //throw new ArgumentException("WAIT A MINUTE !!!");
                await context.Response.WriteAsync($"Hello {user}");
            });
        }

        private void RegisterConfigurationManager(IHostingEnvironment env)
        {
            ConfigurationBuilder config = new ConfigurationBuilder();
            config.SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = config.Build();
        }
    }
}
