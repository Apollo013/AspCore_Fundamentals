using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace StaticFiles
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Default to 'index.html' under 'wwwroot' directory
            app.UseDefaultFiles();

            // Default to 'home.html' under 'wwwroot/views' directory ( *** REMOVE PREVIOUS CODE *** )
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add(@"views/home.html");
            app.UseDefaultFiles(options);

            // Serve up static files under 'wwwroot' directory
            app.UseStaticFiles();

            // Serve up static files from images folder under 'root' directory
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"images")),
                RequestPath = new PathString("/img")
            });


            // This combines UseDefaultFiles() and UseStaticFiles()
            // app.UseFileServer();

            // Default hello page
            app.UseWelcomePage("/hello");

            loggerFactory.AddConsole();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
