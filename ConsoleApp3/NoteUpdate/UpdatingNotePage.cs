using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class UpdatingNotePage : Menu
    {
        protected override Dictionary<string, IPage> Options { get; }
        protected override string Title => $"Змiнна даних запису з Id: {_note.Id}";

        private Note _note;
        private NotePage _notePage;

        public UpdatingNotePage(Note note, IPage allNotes)
        {
            _note = note;
            _notePage = new NotePage(_note, allNotes);

            Options = new Dictionary<string, IPage>()
            {
                {$"Дата: {note.Date}", new DateUpdatePage(_note, _notePage)},
                {$"Тривалicть (у хвилинах): {note.DurationInMin}", new DurationUpdatePage(_note, _notePage)},
                {$"Мiсце проведення: {note.Venue}", new VenueUpdatePage(_note, _notePage)},
                {$"Iнформацiя: {note.Info}", new InfoUpdatePage(_note, _notePage)},
                {"Повернутися", _notePage}
            };
        }
    }
}
