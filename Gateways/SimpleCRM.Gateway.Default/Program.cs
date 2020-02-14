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
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

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
                    //.AddJsonFile("ocelot.json")
                     .AddJsonFile("v1/notes.json")
                    .AddJsonFile("v1/contacts.json")
                    
                    //  .AddJsonFile("v1/tags.json") //Only one can be added :(
                    .AddEnvironmentVariables();

                })
                .ConfigureServices(s =>
                {
                    s.AddHealthChecks()
                    .AddUrlGroup(new Uri("https://localhost:44334/hb"), "contacts service")
                    .AddUrlGroup(new Uri("https://localhost:44387/hb"), "notes service");
                    //.AddAsyncCheck("Http", async () =>
                    //{
                    //    using (HttpClient client = new HttpClient())
                    //    {
                    //        try
                    //        {
                    //            var response = await client.GetAsync("http://localhost:5000");
                    //            if (!response.IsSuccessStatusCode)
                    //            {
                    //                throw new Exception("Url not responding with 200 OK");
                    //            }
                    //        }
                    //        catch (Exception)
                    //        {
                    //            return await Task.FromResult(HealthCheckResult.Failed());
                    //        }
                    //    }
                    //    return await Task.FromResult(HealthCheckResult.Passed());
                    //});
                    s.AddHealthChecksUI();
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
                    

                })
                .ConfigureLogging((logging) =>
                {
#if DEBUG
                    logging.AddConsole();
#endif
                })
                .Configure(a =>
                {
                    a.UseHealthChecks("/hb", new HealthCheckOptions()
                    {
                        Predicate = _ => true,
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    })
       .UseHealthChecksUI(setup =>
       {
           setup.ApiPath = "/hc-api";
           setup.UIPath = "/hc-ui";
       });
                    a.UseRouting();
                    a.UseEndpoints(config =>
                    {
                        config.MapHealthChecksUI();
                    });
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
