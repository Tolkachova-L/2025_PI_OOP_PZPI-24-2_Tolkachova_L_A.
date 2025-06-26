using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class HelpPage : BasePage
    {
        private IPage _previous;

        public HelpPage(IPage previous) 
        {
            _previous = previous;
        }

        protected override IPage RunImpl()
        {
            Console.Clear();
            Console.WriteLine("F1 - допомога");
            Console.WriteLine("ENTER - вибрати/пiдтвердити");
            Console.WriteLine("ESC - повернутися назад");
            Console.WriteLine("ARROW UP '↑' - попереднiй пункт меню");
            Console.WriteLine("ARROW DOWN '↓' - наступний пункт меню");
            Console.WriteLine("Щоб ввийти при додаваннi нового запису, при введенi даних введiть 'CANCEL' ");
            Console.WriteLine("Якщо цi або iншi кнопки будуть виконувати iншi функцiї, iнформацiя про це буде вказана текстом на почаку або в кiнцi сторiнки");
            Console.ReadKey(true);
            return _previous;
        }
    }
}
