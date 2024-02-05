using System;
using System.Collections.Generic;
using Egzamin2024.Interfaces;
using Egzamin2024.Models;
/*Mikołaj Handzlik 14273*/
namespace Egzamin2024.Models
{
    public class NoteService
    {
        private readonly IDateProvider _dateProvider;
        private readonly List<Note> _notes;  // Przykładowa lista notatek w pamięci

        public NoteService(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider ?? throw new ArgumentNullException(nameof(dateProvider));
            _notes = new List<Note>();
        }

        public void Add(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            note.Deadline = _dateProvider.CurrentDate; // Zmiana z CreatedAt na Deadline
            _notes.Add(note);
        }

        public IEnumerable<Note> GetAll()
        {
            return _notes.FindAll(note => note.Deadline < _dateProvider.CurrentDate);
        }

        public Note GetById(string title)
        {
            return _notes.Find(note => note.Title == title);
        }

    }
}
