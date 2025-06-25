using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class DurationUpdatePage : BasePage
    {
        private Note _note;
        private NoteManager _noteManager = new NoteManager();
        private IPage _previous;
        private int _duration;
        private string _error = "";

        public DurationUpdatePage(Note note, IPage previous)
        {
            _note = note;
            _previous = previous;
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine("Змiна даних ТРИВАЛIСТЬ\n");
            Console.WriteLine("Щоб ввийти, введiть в консоль 'CANCEL'\n");
            Console.WriteLine("Старе значення:");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.DurationInMin);
            Console.ResetColor();

            
            
            if (_duration > 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Введiть тривалiсть подiї запису у хвилинах");

                Helpers.PrintErrorIfNeeded(_error);

                string durationString = Console.ReadLine();

                if (durationString == "CANCEL")
                {
                    _error = null;
                    _duration = 0;
                    return _previous;
                }
                var IsInt = int.TryParse(durationString, out _duration);
                if (!IsInt || _duration <= 0)
                {
                    _error = "ПОМИЛКА\n" +
                        "Тривалiсть має бути числом\n" +
                        "Тривалiсть не може бути від'ємною або 0\n" +
                        "Повторiть спробу";
                    return this;
                }
                _error = null;
                return this;
            }
            _note.DurationInMin = _duration;
            _noteManager.UpdateNote(_note);

            _error = null;
            _duration = 0;

            Console.WriteLine();
            Console.WriteLine("Нове значення:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.DurationInMin);
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
