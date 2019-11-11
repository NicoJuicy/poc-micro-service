using NoteService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Core.Repositories
{
    public interface INoteRepository
    {
        void AddNote(Note item);
        Task<Note> GetNoteAsync(Guid id);
        Task<IReadOnlyList<Note>> GetNotesAsync();
        void UpdateNote(Note item);
        void DeleteNote(Note item);
    }
}
