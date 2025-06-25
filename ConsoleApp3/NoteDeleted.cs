using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class NoteDeleted : BasePage
    {
        private IPage _previous;
        private Note _note;
        private NoteManager _noteManager = new NoteManager();

        public NoteDeleted(IPage previous, Note note)
        {
            _previous = previous;
            _note = note;
        }

        protected override IPage RunImpl()
        {
            _noteManager.DeleteNote(_note);
            Console.WriteLine("ЗАПИС ВИДАЛЕНО");
            Console.WriteLine("Натиснiть будь-яку кнопку, щоб переглянути всi записи");
            Console.ReadKey(true);
            return _previous;
        }
    }
}
