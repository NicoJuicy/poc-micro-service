using Marten;
using ContactService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroService.Infrastructure;

namespace ContactService.Infrastructure.Repositories
{
    public class MartenDataStore : IDataStore
    {
        private readonly IDocumentSession session;
        private readonly IContactRepository contacts;

        public MartenDataStore(IDocumentStore documentStore, TenantInfo tenantInfo)
        {
            session = documentStore.LightweightSession(tenantInfo.Name);
            contacts = new ContactRepository(session);
        }

        public IContactRepository Contacts => contacts;

        public async Task CommitChanges()
        {
            await session.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                session.Dispose();
            }

        }
    }
}
