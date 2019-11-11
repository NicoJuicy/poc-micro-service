using ContactService.Infrastructure.Repositories;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

namespace ContactService.Infrastructure.Dependency
{
    public static class MartenInstaller
    {
        public static void AddMarten(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(CreateContactStore(connectionString));
            services.AddScoped<IDataStore, MartenDataStore>();
        }

        private static IDocumentStore CreateContactStore(string connectionString)
        {
            return DocumentStore.For(_ =>
            {
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


            });
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
