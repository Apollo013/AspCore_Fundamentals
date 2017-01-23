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
using ConfigurationManagement.Services;
using ConfigurationManagement.Models;

namespace ConfigurationManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            RegisterConfigurationBuilder(hostingEnvironment);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAppSettingsFormatter settingsFormatter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(settingsFormatter.Format(new { Message = "Hello World!" }));
            });
        }


        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton((provider) => { return ReadMeasurements(); });
            services.Configure<Favourites>((options) => { ReadFavourites(options); });
            services.AddSingleton(Configuration);
            services.AddSingleton<IAppSettingsFormatter, AppSettingsFormatter>();
        }

        private void RegisterConfigurationBuilder(IHostingEnvironment hostingEnvironment)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = configBuilder.Build();
        }

        /// <summary>
        /// Read Measurements section from appsettings.json
        /// </summary>
        /// <returns></returns>
        private Measurements ReadMeasurements()
        {
            Measurements measurements = new Measurements();
            measurements.Height = Convert.ToInt32(Configuration["Measures:Height"]);
            measurements.Length = Convert.ToInt32(Configuration["Measures:Length"]);
            measurements.Type = Configuration["Measures:Type"];
            measurements.Width = Convert.ToInt32(Configuration["Measures:Width"]);
            return measurements;
        }

        /// <summary>
        /// Read Favourites section from appsettings.json
        /// </summary>
        /// <param name="opt"></param>
        private void ReadFavourites(Favourites favourites)
        {
            favourites.Food = Configuration["Favourites:Food"];
            favourites.Music = Configuration["Favourites:Music"];
            favourites.Technology = Configuration["Favourites:Technology"];
        }
    }
}
