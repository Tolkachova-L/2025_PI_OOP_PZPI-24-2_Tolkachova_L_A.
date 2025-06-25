using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class VenueUpdatePage : BasePage
    {
        private Note _note;
        private NoteManager _noteManager = new NoteManager();
        private IPage _previous;
        private string _venue = "";
        private string _error = "";

        public VenueUpdatePage(Note note, IPage previous)
        {
            _note = note;
            _previous = previous;
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine("Змiна даних МIСЦЕ ПРОВЕДЕННЯ\n");
            Console.WriteLine("Щоб ввийти, введiть в консоль 'CANCEL'\n");
            Console.WriteLine("Старе значення:");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.Venue);
            Console.ResetColor();

            
            if (_venue != "")
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Введiть мiсце проведення");

                Helpers.PrintErrorIfNeeded(_error);

                _venue = Console.ReadLine();

                if (_venue == "CANCEL")
                {
                    _error = null;
                    _venue = "";
                    return _previous;
                }
                if (_venue == "")
                {
                    _error = "ПОМИЛКА\n" +
                        "Це поле не може бути пустим\n" +
                        "Повторiть спробу";
                    return this;
                }
                _error = null;
                return this;
            }

            _note.Venue = _venue;
            _noteManager.UpdateNote(_note);

            _error = null;
            _venue = "";

            Console.WriteLine("Нове значення:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.Venue);
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Запис оновленно");
            Console.WriteLine();
            Console.WriteLine("Натиснiть ESC, щоб повернутися до даних запису");

            do
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    return _previous;
                }
            }
            while (true);
        }
    }
}
