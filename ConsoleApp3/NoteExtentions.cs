using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal static class NoteExtentions
    {
        public static string GetNoteHead(this Note note)
        {
            return $"Id: {note.Id}, Дата: {note.Date}, Iнформацiя: {note.Info}";
        }
    }
}
