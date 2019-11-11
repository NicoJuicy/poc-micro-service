using ContactService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Core.Repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact item);
        Task<Contact> GetContactAsync(Guid id);
        Task<IReadOnlyList<Contact>> GetContactsAsync();
        void UpdateContact(Contact item);
        void DeleteContact(Contact item);

        void AddContactNote(Guid contactId, Guid noteId);
        void DeleteContactNote(Guid contactId, Guid noteId);

        void AddContactTag(Guid contactId, Guid tagId);
        void DeleteContactTag(Guid contactId, Guid tagId);

    }
}
