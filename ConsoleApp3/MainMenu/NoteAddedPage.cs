using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class NoteAddedPage : BasePage
    {
        private IPage _previous;

        public NoteAddedPage(IPage previous)
        {
            _previous = previous;
        }

        protected override IPage RunImpl()
        {
            Console.WriteLine("ЗАПИС ЗБЕРЕЖЕНО");
            Console.WriteLine();
            Console.WriteLine("Натиснiть будь-яку кнопку, щоб повенутися до головного меню");
            Console.ReadKey(true);
            return _previous;
        }
    }
}
