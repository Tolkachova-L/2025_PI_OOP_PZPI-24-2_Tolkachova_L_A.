using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class AddNewNotePage : BasePage
    {
        private IPage _previousPage;
        private NoteManager _noteManager = new NoteManager();
        private NoteAddedPage _noteAddedPage;

        //стани класу
        private string _error;
        private DateTime _date = DateTime.MinValue;
        private int _duration = -1;
        private string _venue = "";
        private string _info = "";

        //конструктор класу
        public AddNewNotePage(IPage previous)
        {
           _previousPage = previous;
           _noteAddedPage = new NoteAddedPage(previous);
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine("СТВОРЕННЯ НОВОГО ЗАПИСУ");
            Console.WriteLine();
            Console.WriteLine("При натисканнi ENTER данi зберiгаються");
            Console.WriteLine("Щоб ввийти, введiть в консоль 'CANCEL'");
            Console.WriteLine();

            //перевіряє чи підходить дата за критеріями
            if (_noteManager.ValidateStartTime(_date))
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Дата: " + _date);
                Console.ResetColor();
            }
            else
            {
                //якщо післч методу він повертає "CANCEL", програма повертає на попередню сторінку
                Helpers.TryReadDateTime(ref _error, out _date);
                if (_error == "CANCEL")
                {
                    ClearState();
                    return _previousPage;
                }
                else return this;
            }


            Console.WriteLine("Введiть тривалiсть  запису у хвилинах");
            if (_duration > 0)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Тривалiсть: " + _duration + " хвилин");
                Console.ResetColor();
            }
            else
            {
                Helpers.PrintErrorIfNeeded(_error);

                string durationString = Console.ReadLine();

                if (durationString == "CANCEL")
                {
                    ClearState();
                    return _previousPage;
                }

                var IsInt = int.TryParse(durationString, out _duration);
                if (!IsInt || _duration <= 0)
                {

                    _error = "ПОМИЛКА\n" +
                        "Тривалiсть має бути числом\n" +
                        "Тривалiсть не може бути вiд'ємною або 0\n" +
                        "Повторiть спробу";

                    return this;
                }
                _error = null;
                return this;
            }


            Console.WriteLine("Введiть мiсце проведення");
            if (_venue != "")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Мiсце проведення: " + _venue);
                Console.ResetColor();
            }
            else
            {
                Helpers.PrintErrorIfNeeded(_error);

                _venue = Console.ReadLine();

                if (_venue == "CANCEL")
                {
                    ClearState();
                    return _previousPage;
                }
                else if (_venue == "")
                {
                    _error = "ПОМИЛКА\n" +
                        "Це поле не може бути пустим\n" +
                        "Повторiть спробу";
                    return this;
                }
                _error = null;
                return this;
            }


            Console.WriteLine("Ведiть додаткову iнформацiю про подiю");
            if (_info != "")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Iнформацiя: " + _info);
                Console.ResetColor();
            }
            else
            {
                Helpers.PrintErrorIfNeeded(_error);

                _info = Console.ReadLine();

                if (_info == "CANCEL")
                {
                    ClearState();
                    return _previousPage;
                }
                else if (_info == "")
                {
                    _error = "ПОМИЛКА\n" +
                        "Це поле не може бути пустим\n" +
                        "Повторiть спробу";
                    return this;
                }
                _error = null;
                return this;
            }

            var note = _noteManager.BuildNote(_date, _duration, _venue, _info);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Натиснiть ENTER, щоб зберегти");
            Console.WriteLine("Натиснiть ESC, щоб ввийти");
            Console.WriteLine("Натиснiть SPACEBAR, щоб почати знову");

            ClearState();

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    _noteManager.AddNote(note);
                    return _noteAddedPage;
                }
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    return _previousPage;
                }
                if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                {
                    return this;
                }
            }

        }

        private void ClearState()
        {
            _date = DateTime.MinValue;
            _error = null;
            _duration = -1;
            _venue = "";
            _info = "";
        }
    }
}
