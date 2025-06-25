using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class NoteManager
    {
        private INoteRepository _repo = new FileNoteRepository();

        public Note BuildNote(DateTime date, int duration, string venue, string info)
        {
            var note = new Note()
            {
                Id = GetNextId(),
                Date = date,
                DurationInMin = duration,
                Venue = venue,
                Info = info
            };
            return note;
        }

        public List<Note> GetNotes()
        {
            return _repo.GetAll();
        }

        public void AddNote(Note note)
        {
            _repo.Add(note);
        }

        public void DeleteNote(Note note)
        {
            _repo.Remove(note.Id);
        }

        public void UpdateNote(Note note)
        {
            _repo.Update(note);
        }

        public void RemoveObsolete()
        {
            _repo.RemoveObsolete();
        }
        private int GetNextId()
        {
            var notes = GetNotes();
            if(notes.Count == 0)
            {
                return 1;
            }
            
            return notes.Max(x => x.Id)+1;
        }

        public bool ValidateStartTime(DateTime startTime)
        {
            if(startTime < DateTime.Now)
            {
                return false;
            }

            var allNotes = GetNotes();
            foreach(var note in allNotes)
            {
                if (startTime >= note.Date && startTime < note.Date.AddMinutes(note.DurationInMin))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateTime(DateTime startTime, int duration)
        {
            if (!ValidateStartTime(startTime))
            {
                return false;
            }

            if (!ValidateStartTime(startTime.AddMinutes(duration)))
            {
                return false;
            }

            var allNotes = GetNotes();
            foreach(var note in allNotes)
            {
                if(startTime <= note.Date && startTime.AddMinutes(duration) >= note.Date.AddMinutes(note.DurationInMin))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
