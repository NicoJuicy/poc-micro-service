using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
namespace SimpleCRM.Gateway.Default
{
    public class Program
    {
        //GET = WORKING https://localhost:44334/api/contacts/b24a89d2-ca1a-48b2-b19f-dfe172d9ac51
        //GET = WORKING https://localhost:44334/api/contacts
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   //.UseStartup<Startup>()
                   .UseUrls("http://*:9000")
                   .ConfigureAppConfiguration((hostingContext, config) =>
                   {
                       config
                           .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                           .AddJsonFile("ocelot.json")
                           .AddEnvironmentVariables();
                   })
               .ConfigureServices(s =>
               {
                   s.AddOcelot();
                   s.AddMvc();
               })
                .Configure(a =>
                {
                    a.UseOcelot().Wait();
                });

        // public static void Main(string[] args)
        // {
        //     IWebHostBuilder builder = new WebHostBuilder();
        //     builder.ConfigureServices(s =>
        //     {
        //         s.AddSingleton(builder);
        //     });
        //     builder.UseKestrel()
        //            .UseContentRoot(Directory.GetCurrentDirectory())
        //            .UseStartup<Startup>()
        //            .UseUrls("http://localhost:9000");

        //     var host = builder.Build();
        //     host.Run();
        // }
    }
}
