using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class AllNotesPage : Menu
    {
        protected NoteManager NoteManager = new NoteManager();
        protected override Dictionary<string, IPage> Options => GetOptions(NoteManager.GetNotes());
        protected override string Title => "Переглянути всi записи\n" +
            "Якщо список пустий, натиснiть ESC або ENTER, щоб повернутися\n";
        private IPage _previousPage;

        public AllNotesPage(IPage previous)
        {
            _previousPage = previous;
        }

        protected Dictionary<string, IPage> GetOptions(List<Note> notes)
        {
            var dict = notes.ToDictionary(n => n.GetNoteHead(), n => (IPage)new NotePage(n, this));
            return dict;
        }

        protected override IPage ProccesKey(ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.Escape)
            {
                return _previousPage;
            }
            if (keyPressed == ConsoleKey.F1)
            {
                return new HelpPage(this);
            }
            return null;
        }
    }
}
