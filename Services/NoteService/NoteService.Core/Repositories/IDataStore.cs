using NoteService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Infrastructure.Repositories
{
    public interface IDataStore : IDisposable
    {
        INoteRepository Notes { get; }

        Task CommitChanges();
    }
}
