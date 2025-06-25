using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class NotesForNeededDayPage : AllNotesPage
    {
        protected override Dictionary<string, IPage> Options => GetOptions(GetTomorrowNotes());
        protected override string Title => $"Переглянути всi записи на {_date.Date}\n" +
            "Якщо список пустий, натиснiть ESC або ENTER, щоб повернутися\n";
        private DateTime _date;

        public NotesForNeededDayPage(DateTime date, IPage previous) : base(previous)
        {
            _date = date;
        }

        private List<Note> GetTomorrowNotes()
        {
            var notes = NoteManager.GetNotes();
            var tomorrowNotes = notes.Where(n => n.Date.Date == _date.Date)
                .ToList();
            return tomorrowNotes;
        } 
    }
}
