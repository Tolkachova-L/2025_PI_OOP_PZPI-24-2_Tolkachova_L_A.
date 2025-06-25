using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class Menu : BasePage
    {
        private int SelectedIndex = 0;
        protected abstract Dictionary<string, IPage> Options { get; }
        private string[] _keys => Options.Keys.ToArray();
        protected abstract string Title { get; }
        protected virtual string Footer { get; }



        private void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine(Title);

            foreach (var option in Options)
            {
                string prefix;

                if (option.Key == _keys[SelectedIndex])
                {
                    prefix = "  ";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = "";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix} << {option.Key} >>");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(Footer);
        }

        protected override IPage RunImpl()
        {
            SelectedIndex = 0;
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;



                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex --;
                    if(SelectedIndex <= -1)
                    {
                        SelectedIndex = _keys.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex >= _keys.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.Enter)
                {

                    if (Options == null || _keys == null || SelectedIndex < 0 || SelectedIndex >= _keys.Length)
                    {
                        return new MainMenu();
                    }
                    else return Options[_keys[SelectedIndex]];
                }

                var page = ProccesKey(keyPressed);
                if (page != null)
                {
                    return page;
                }

            } while (true);

        }

        protected virtual IPage ProccesKey(ConsoleKey keyPressed)
        {
            return null;
        }
    }
}
