using ContactService.Core.Events;
using MicroService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Core.Entities
{
    public class Contact : AggregateRoot
    {
        public Contact(Guid id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;

        }
        //public Guid Id { get; set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Email { get; private set; }

        public ComplexTypes.Address Address { get; private set; }

        public string Phone { get; private set; }


        public void ChangeAddress(ComplexTypes.Address address)
        {
            this.Address = address;
            AddEvent(new Events.ContactAddressChanged(this));
        }

        public void ChangeEmail(string email)
        {
            this.Email = email;
            AddEvent(new Events.ContactEmailChanged(this));
        }

        private ISet<Guid> _notes = new HashSet<Guid>();
        public IEnumerable<Guid> Notes
        {
            get => _notes;
            set => _notes = new HashSet<Guid>(value);
        }

        private ISet<Guid> _tags = new HashSet<Guid>();
        public IEnumerable<Guid> Tags
        {
            get => _tags;
            set => _tags = new HashSet<Guid>(value);
        }


        public void AddNote(Guid noteId)
        {
            if (_notes.Contains(noteId) || noteId == Guid.Empty) return;

            _notes.Add(noteId);
        }

        public void AddTag(Guid tagId)
        {
            if (_tags.Contains(tagId) || tagId == Guid.Empty) return;

            _notes.Add(tagId);
        }

        public void DeleteNote(Guid noteId)
        {
            if (!_notes.Contains(noteId) || noteId == Guid.Empty) return;

            _notes.Remove(noteId);
        }
        public void DeleteTag(Guid tagId)
        {
            if (!_tags.Contains(tagId) || tagId == Guid.Empty) return;

            _tags.Remove(tagId);
        }
    }
}
