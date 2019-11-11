using Marten;
using NoteService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Infrastructure.Repositories
{
    public class MartenDataStore : IDataStore
    {
        private readonly IDocumentSession session;
        private readonly INoteRepository notes;

        public MartenDataStore(IDocumentStore documentStore)
        {
            session = documentStore.LightweightSession();
            notes = new NoteRepository(session);
        }

        public INoteRepository Notes => notes;

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
