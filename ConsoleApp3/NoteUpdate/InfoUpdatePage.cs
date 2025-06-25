using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class InfoUpdatePage : BasePage
    {
        private Note _note;
        private NoteManager _noteManager = new NoteManager();
        private IPage _previous;
        private string _info = "";
        private string _error = "";

        public InfoUpdatePage(Note note, IPage previous)
        {
            _note = note;
            _previous = previous;
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine("Змiна даних IНФОРМАЦIЯ\n");
            Console.WriteLine("Щоб ввийти, введiть в консоль 'CANCEL'\n");
            Console.WriteLine("Старе значення:");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.Info);
            Console.ResetColor();

            
            
            if (_info != "")
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ведiть додаткову iнформацiю про запис");

                Helpers.PrintErrorIfNeeded(_error);

                _info = Console.ReadLine();

                if (_info == "CANCEL")
                {
                    _error = null;
                    _info = "";
                    return _previous;
                }
                if (_info == "")
                {
                    _error = "ПОМИЛКА\n" +
                        "Це поле не може бути пустим\n" +
                        "Повторiть спробу";
                    return this;
                }
                _error = null;
                return this;
            }

            _note.Info = _info;
            _noteManager.UpdateNote(_note);

            Console.WriteLine();
            Console.WriteLine("Нове значення:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(_note.Info);
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Запис оновленно");
            Console.WriteLine();
            Console.WriteLine("Натиснiть ESC, щоб повернутися до даних запису");

            _error = null;
            _info = "";

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
