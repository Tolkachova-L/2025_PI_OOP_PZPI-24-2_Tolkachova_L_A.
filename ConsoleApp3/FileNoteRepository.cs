using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp3
{
    internal class FileNoteRepository : INoteRepository
    {
        private static string _relPath = "../../AllNotesData.json";
        private static string _fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relPath); 

        public FileNoteRepository()
        {
            var exists = File.Exists(_fullPath);
            if (!exists)
            {
                File.Create(_fullPath);
            }
        }

        public List<Note> GetAll()
        {
            string jsonContent = File.ReadAllText(_fullPath);
            var allNotes = JsonConvert.DeserializeObject<List<Note>>(jsonContent);
            return allNotes ?? new List<Note>(); 
        }

        public Note Get(int id) 
           => GetAll().FirstOrDefault(x => x.Id == id);
        
        public Note Add(Note note)
        {
            var notes = GetAll();
            notes.Add(note);
            WriteNotesToFile(notes);
            return note;
        }

        public Note Remove(int id)
        {
            var notes = GetAll();
            var noteToRemove = notes.FirstOrDefault(x => x.Id == id);
            if(noteToRemove == null)
            {
                return null;
            }
            notes.Remove(noteToRemove);
            WriteNotesToFile(notes);
            return noteToRemove;
        }

        public void RemoveObsolete()
        {
            var notes = GetAll();
            notes.RemoveAll(x => x.Date < DateTime.Now);
            WriteNotesToFile(notes);
        }
        public Note Update(Note note)
        {
            var oldNote = Remove(note.Id);
            Add(note);
            return oldNote;
        }

        public static void WriteNotesToFile(List<Note> notes)
        {
            var notesSerialized = JsonConvert.SerializeObject(notes);
            File.WriteAllText(_fullPath, notesSerialized);
        }
    }
}
