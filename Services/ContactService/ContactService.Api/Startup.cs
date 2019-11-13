using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ContactService.Application.CQRS.Commands;
using ContactService.Application.CQRS.Commands.Handlers;
using ContactService.Application.Dependency;
using ContactService.Infrastructure.Dependency;
using ElmahCore.Mvc;
using MediatR;
using MicroService.WebApi.Middleware;
using MicroService.WebApi.Strategy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using SimpleCRM.Infrastructure.MessageBroker.Nats;

namespace ContactService.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateContactHandler).GetTypeInfo().Assembly);// typeof(Startup).GetTypeInfo().Assembly);
            services.AddApplication();
            services.AddInfrastructure(Configuration.GetConnectionString("PgConnection"));

            services.AddSingleton<IEventBus>(CreateNatsBus(Configuration.GetSection("MessageBus:Nats:Ip").Get<string[]>()));
            services.AddHealthChecks();
            services.AddElmah();
            services.AddControllers();

              services.AddSingleton<ITenantStrategy, TenantFromRequestHeaderStrategy>();
            services.AddScoped<ITenantMiddleWare>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {


            app.UseRouting();
            app.UseCors();
            app.UseElmah();
            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }

        private static IEventBus CreateNatsBus(string[] ips)
        {
            return new NatsEventBus<IEvent>(ips);
        }
    }
}
