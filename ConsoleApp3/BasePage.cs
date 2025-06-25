using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class BasePage : IPage
    {
        private NoteManager _noteManager = new NoteManager();

        public IPage Run()
        {
            _noteManager.RemoveObsolete();
            Console.Clear();
            return RunImpl();
        }
        protected abstract IPage RunImpl();


    }
}
