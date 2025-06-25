using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface INoteRepository
    {
        Note Get(int id);
        List<Note> GetAll();
        Note Add(Note note);

        Note Remove(int id);

        void RemoveObsolete();

        Note Update(Note note);
    }
}
