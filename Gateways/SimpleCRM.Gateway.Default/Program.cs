using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Ocelot.Middleware;
using Ocelot.Administration;
using System;
using IdentityServer4.AccessTokenValidation;
using Ocelot.Provider.Consul;

namespace SimpleCRM.Gateway.Default
{
    //https://buildmedia.readthedocs.org/media/pdf/ocelot/latest/ocelot.pdf
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
                .UseIIS()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("ocelot.json")
                    .AddJsonFile("v1/contacts.json")
                    .AddJsonFile("v1/notes.json")
                    .AddJsonFile("v1/tags.json")
                    .AddEnvironmentVariables();

                })
                .ConfigureServices(s =>
                {
                    s.AddOcelot();//.AddConsul();
                    //var authenticationProviderKey = "TestKey";
                    //s.AddAuthentication().AddJwtBearer(authenticationProviderKey, x =>
                    //{
                    //    x.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                    //    {
                    //        OnTokenValidated = async ctx =>
                    //        {
                    //            var claims = new List<Claim>
                    //          {
                    //                new Claim("Tenant", "Test")
                    //          };
                    //            var appIdentity = new ClaimsIdentity(claims);
                    //            ctx.Principal.AddIdentity(appIdentity);
                    //        }

                    //    };
                    //});
                    //s.AddAdministration("/administration", "secret");
                    s.AddMvc();

                })
                .ConfigureLogging((logging) =>
                {
#if DEBUG
                    logging.AddConsole();
#endif
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
