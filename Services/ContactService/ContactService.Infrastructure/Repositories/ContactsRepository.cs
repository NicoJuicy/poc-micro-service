using Marten;
using ContactService.Core.Entities;
using ContactService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDocumentSession session;

        public ContactRepository(IDocumentSession session)
        {
            this.session = session;
        }

        public void AddContact(Contact item)
        {
            session.Insert(item);
        }

        public void AddContactNote(Guid contactId, Guid noteId)
        {
            session.Patch<Contact>(contactId).AppendIfNotExists(el => el.Notes, noteId);
        }

        public void AddContactTag(Guid contactId, Guid tagId)
        {
            session.Patch<Contact>(contactId).AppendIfNotExists(el => el.Tags, tagId);
        }

        public void DeleteContact(Contact item)
        {
            session.Delete(item);
        }

        public void DeleteContactNote(Guid contactId, Guid noteId)
        {
            session.Patch<Contact>(contactId).Remove(el => el.Notes, noteId);
        }

        public void DeleteContactTag(Guid contactId, Guid tagId)
        {
            session.Patch<Contact>(contactId).Remove(el => el.Notes, tagId);

        }

        public async Task<Contact> GetContactAsync(Guid id)
        {
            return await session.Query<Contact>().FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task<IReadOnlyList<Contact>> GetContactsAsync()
        {
            return await session.Query<Contact>().ToListAsync();
        }

        public void UpdateContact(Contact item)
        {
            session.Update(item);
       
        }
    }
}
