using Marten;
using Microsoft.Extensions.DependencyInjection;
using Marten.Services;
using NoteService.Infrastructure.Repositories;

namespace NoteService.Infrastructure.Dependency
{
    public static class MartenInstaller
    {
        public static void AddMarten(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(CreateNoteStore(connectionString));
            services.AddScoped<IDataStore, MartenDataStore>();
        }

        private static IDocumentStore CreateNoteStore(string connectionString)
        {
            return DocumentStore.For(_ =>
            {
                _.Connection(connectionString);
                _.DatabaseSchemaName = "note_service";
                //  _.Serializer(CustomizeJsonSerializer());
                _.PLV8Enabled = false; // https://jasperfx.github.io/marten/documentation/documents/advanced/javascript_transformations/
                _.Schema.For<Documents.NoteDocument>().Duplicate(el => el.On, configure: idx =>
                {
                    idx.SortOrder = SortOrder.Desc;
                  
                });
                
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
