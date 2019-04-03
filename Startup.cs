using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Console = Colorful.Console;

namespace HTTPListener
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run((context) => {
                using(var stream = new StreamReader(context.Request.Body))
                {
                    Console.WriteAscii("NEW REQUEST", Color.Blue);
                    Console.WriteLine($"[{context.Request.Protocol}] {(context.Request.IsHttps ? "https://" : "http://")}{context.Request.Host.Value}{context.Request.Path}{context.Request.QueryString.Value} - {context.Request.Method}");
                    Console.WriteLine("**************************", Color.Green);
                    Console.WriteLine("HEADERS", Color.Green);
                    Console.WriteLine("**************************", Color.Green);
                    foreach(var header in context.Request.Headers)
                    {
                        Console.WriteLine($"{header.Key}: {header.Value}");
                    }
                    Console.WriteLine("**************************", Color.Green);
                    Console.WriteLine("COOKIES", Color.Green);
                    Console.WriteLine("**************************", Color.Green);
                    foreach(var cookie in context.Request.Cookies)
                    {
                        Console.WriteLine($"{cookie.Key}: {cookie.Value}");
                    }
                    Console.WriteLine("**************************", Color.Green);
                    Console.WriteLine("FORM", Color.Green);
                    Console.WriteLine("**************************", Color.Green);
                    if(context.Request.HasFormContentType)
                    {
                        foreach(var form in context.Request.Form)
                        {
                            Console.WriteLine($"{form.Key}: {form.Value}");
                        }
                    }
                    Console.WriteLine("**************************", Color.Green);
                    Console.WriteLine("BODY", Color.Green);
                    Console.WriteLine("**************************", Color.Green);
                    Console.WriteLine(stream.ReadToEnd());
                }

                return Task.FromResult(new OkResult());
            });
        }
    }
}
