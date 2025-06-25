using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ConsoleApp3
{
    internal class GetDayForNotesPage : BasePage
    {
        private NoteManager _noteManager = new NoteManager();
        private IPage _previous;
        private string _error = "";
        DateTime _date = DateTime.MinValue;

        public GetDayForNotesPage(IPage previous)
        {
            _previous = previous;
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine("Введiть дату потрiбних записiв");

            if (_error == "CANCEL")
            {
                _error = "";
                _date = DateTime.MinValue;
                return _previous;
            }
            else if (_noteManager.ValidateStartTime(_date))
            {
                Console.WriteLine();
            }
            else
            {
                Helpers.TryReadDate(ref _error, out _date);
                return this;
            }
            var notesPage = new NotesForNeededDayPage(_date, _previous);

            _error = "";
            _date = DateTime.MinValue;

            return notesPage;
        }
    }
}
