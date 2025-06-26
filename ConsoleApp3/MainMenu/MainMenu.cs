using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class MainMenu : Menu
    {
        protected override Dictionary<string, IPage> Options { get; }
        protected override string Title => "Щоденник\n" +
            "(Рекомендуємо натиснути F1 та прочитати основнi функцiї кнопок)\n";
        private NoteManager _noteManager = new NoteManager();
        public MainMenu()
        {
            Options = new Dictionary<string, IPage>
            {
                {"Переглянути всi записи", new AllNotesPage(this)},
                {"Додати новий запис", new AddNewNotePage(this)},
                {"Переглянути записи на певний день", new GetDayForNotesPage(this)},
                {"Вийти", null}
            };
        }
        protected override IPage ProccesKey(ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.F1)
            {
                return new HelpPage(this);
            }
            return null;
        }
    }
}
