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
            protected override string Title => GetClosestNote();
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
        private string GetClosestNote()
        {
            string neededNote = "";
            var allNotes = _noteManager.GetNotes();
            DateTime? closestDate = null;
            if (allNotes != null && allNotes.Any(x => x != null))
            {
                closestDate = allNotes.Where(x => x != null).Min(x => x.Date);
            }
            if (closestDate == null)
            {
                closestDate = DateTime.MinValue;
            }
            var closestNote = allNotes.Find(x => x.Date == closestDate);

            if (closestDate != DateTime.MinValue && closestNote != null)
            {
                neededNote = $"Найближчий запис: {closestNote.Date}, iнформацiя: {closestNote.Info}";
            }
            else
            {
                neededNote = "Найближчий запис: записiв не знайдено";
            }
            return neededNote;
        }
    }
}
