using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ConsoleApp3
{
    internal class DateUpdatePage : BasePage
    {
        private Note _note;
        private NoteManager _noteManager = new NoteManager();
        private IPage _previous;
        private string _error = "";
        DateTime _date = DateTime.MinValue;


        public DateUpdatePage(Note note, IPage previous)
        {
            _note = note;
            _previous = previous;
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine("Змiна даних ДАТА");
            Console.WriteLine("Старе значення:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.Date);
            Console.ResetColor();
            
            if (_noteManager.ValidateStartTime(_date))
            {
                Console.WriteLine();
            }
            else
            {
                if (_noteManager.ValidateStartTime(_date))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Дата: " + _date);
                    Console.ResetColor();
                }
                else
                {
                    Helpers.TryReadDateTime(ref _error, out _date);
                    if (_error == "CANCEL")
                    {
                        _error = null;
                        return _previous;
                    }
                else return this;
                }
            }

            _note.Date = _date;
            _noteManager.UpdateNote(_note);

            Console.WriteLine();
            Console.WriteLine("Нове значення:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.Date);
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Запис оновленно");
            Console.WriteLine();
            Console.WriteLine("Натиснiть ESC, щоб повернутися до даних запису");

            _error = null;
            _date = DateTime.MinValue;

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    return _previous;
                }
            }
        }
    }
}
