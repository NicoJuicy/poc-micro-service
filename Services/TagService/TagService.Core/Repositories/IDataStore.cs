using TagService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TagService.Infrastructure.Repositories
{
    public interface IDataStore : IDisposable
    {
        ITagRepository Tags { get; }

        Task CommitChanges();
    }
}
