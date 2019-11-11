using ContactService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Infrastructure.Repositories
{
    public interface IDataStore : IDisposable
    {
        IContactRepository Contacts { get; }

        Task CommitChanges();
    }
}
