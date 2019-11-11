using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ElmahCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteService.Application.CQRS.Commands.CreateNote;
using NoteService.Application.Dependency;
using NoteService.Infrastructure.Dependency;
using SimpleCRM.Infrastructure.MessageBroker.Events;
using Swashbuckle.AspNetCore.Swagger;

namespace NoteService.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateNoteHandler).GetTypeInfo().Assembly);// typeof(Startup).GetTypeInfo().Assembly);
            services.AddApplication();
            services.AddInfrastructure(Configuration.GetConnectionString("PgConnection"));
            // services.AddMvc();

            services.AddSingleton<IEventBus>(CreateNatsBus(Configuration.GetSection("MessageBus:Nats:Ip").Get<string[]>()));
          //  services.AddScoped<IEventBus, CreateNatsBus(Configuration.GetSection("MessageBus:Nats:Ip").Get<string[]>());

         //   services.AddRazorPages().AddMvcOptions(options => options.EnableEndpointRouting = true);
            services.AddHealthChecks();
            services.AddElmah();
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Note Api", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)//, IHostingEnvironment env)
        {
            
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}


          //  app.UseMvc();
            app.UseRouting();
            app.UseCors();
            app.UseElmah();
            app.UseDeveloperExceptionPage();
          //  app.UseWelcomePage();

            //app.UseSwagger();
            //app.UseStaticFiles();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meeting Management V1");
            //});

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


        }

        private static IEventBus CreateNatsBus(string[] ips)
        {
            return new SimpleCRM.Infrastructure.MessageBroker.Nats.NatsEventBus<IEvent>(ips);
        }
    }
}
