using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TagService.Core.Entities;

namespace TagService.Core.Repositories
{
    public interface ITagRepository
    {
        void AddTag(Tag item);
        Task<Tag> GetTagAsync(Guid id);
        Task<IReadOnlyList<Tag>> GetContactsAsync();
        void UpdateTag(Tag item);
        void DeleteTag(Tag item);
    }
}
