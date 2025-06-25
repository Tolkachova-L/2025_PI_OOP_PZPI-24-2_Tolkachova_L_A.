using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class NotePage : BasePage
    {
        private Note _note;
        private IPage _previuos;

        public NotePage(Note note, IPage previuos)
        {
            _note = note;
            _previuos = previuos;
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine($"Перегляд запису з Id: {_note.Id}");
            Console.WriteLine();
            Console.WriteLine($"Дата: {_note.Date}");
            Console.WriteLine($"Тривалiсь: {_note.DurationInMin} хвилин");
            Console.WriteLine($"Мiсце проведення: {_note.Venue}");
            Console.WriteLine($"Iнформацiя: {_note.Info}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Натиснiть ESC, щоб повернутися до списку записiв");
            Console.WriteLine("Натиснiть SPACEBAR, щоб змiнити данi запису");
            Console.WriteLine("Натиснiть ENTER, щоб видалити запис");
            
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return _previuos;
                }
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    return new UpdatingNotePage(_note, _previuos);
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return new DeletionConfirmPage(new NoteDeleted(_previuos, _note), this);
                }
            }

        }
    }
}
