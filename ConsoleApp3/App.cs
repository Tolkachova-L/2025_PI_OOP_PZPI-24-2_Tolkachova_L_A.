using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class App
    {
        private IPage _current;


        public void Start()
        {
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            
            _current = new MainMenu();
            
            while (_current != null)
            {
                _current = _current.Run();
            }
            Exit();
        }

        private void Exit()
        {
            Console.Clear();
            Console.WriteLine("Натиснiсть будь-яку кнопку, щоб вийти");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
