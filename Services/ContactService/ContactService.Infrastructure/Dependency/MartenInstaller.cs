using ContactService.Infrastructure.Repositories;
using Marten;
using MicroService.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

namespace ContactService.Infrastructure.Dependency
{
    public static class MartenInstaller
    {
        //https://jasperfx.github.io/marten/getting_started/ - Nog geen correcte IoC implementatie
        public static void AddMarten(this IServiceCollection services,  string connectionString)
        {
            //   services.AddSingleton(CreateContactStore(connectionString));

            //  var tenant = serviceProvider.GetRequiredService<TenantInfo>();
            services.AddScoped<IDataStore, MartenDataStore>();
            services.AddSingleton<IDocumentStore>((serviceProvider) =>
            {
            //     var tenant = serviceProvider.GetRequiredService<TenantInfo>();
            return CreateContactStore(connectionString);//, tenant.Name);
            });
        }

        private static IDocumentStore CreateContactStore(string connectionString)
        {

            var store =  DocumentStore.For(_ =>
            {
                //_.CreateDatabasesForTenants(el => el.ten);
                _.Connection(connectionString);
                _.DatabaseSchemaName = "contact_service";
                //  _.Serializer(CustomizeJsonSerializer());
                
                _.PLV8Enabled = false; // https://jasperfx.github.io/marten/documentation/documents/advanced/javascript_transformations/

                _.Schema.For<Documents.ContactDocument>().Duplicate(el => el.LastName, configure: idx =>
                {
                    idx.SortOrder = SortOrder.Asc;
                });

                var indexedColumns = new Expression<Func<Documents.ContactDocument, object>>[]
                {
                    x => x.FirstName,
                    x => x.LastName,
                    x => x.Email,
                    x => x.Phone
                };

                _.Schema.For<Documents.ContactDocument>().Index(indexedColumns);
                _.Schema.For<Documents.ContactDocument>().MultiTenanted();

            });

            

            return store;
        }

        //private static JsonNetSerializer CustomizeJsonSerializer()
        //{
        //    var serializer = new JsonNetSerializer();

        //    serializer.Customize(_ =>
        //    {
        //        _.ContractResolver = new ProtectedSettersContractResolver();
        //    });

        //    return serializer;
        //}
    }
}
