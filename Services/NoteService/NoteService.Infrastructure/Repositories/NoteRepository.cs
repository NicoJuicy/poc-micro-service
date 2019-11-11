using Marten;
using NoteService.Core.Entities;
using NoteService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly IDocumentSession session;

        public NoteRepository(IDocumentSession session)
        {
            this.session = session;
        }

        public void AddNote(Note item)
        {
            session.Insert(item);
        }
        
        public void DeleteNote(Note item)
        {
            session.Delete(item);
        }

        public async Task<Note> GetNoteAsync(Guid id)
        {
            return await session.Query<Note>().FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task<IReadOnlyList<Note>> GetNotesAsync()
        {
            return await session.Query<Note>().ToListAsync();
        }

        public void UpdateNote(Note item)
        {
            session.Update(item);
       
        }
    }
}
