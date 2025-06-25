using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class DeletionConfirmPage : Menu
    {
        protected override string Title => "ПIДТВЕРДIТЬ ВИДАЛЕННЯ ЗАПИСУ";
        protected override Dictionary<string, IPage> Options { get; }

        public DeletionConfirmPage(IPage confirmPage, IPage regectPage)
        {
            
            Options = new Dictionary<string, IPage>()
            {
                {"ПIДТВЕРДИТИ", confirmPage},
                {"СКАСУВАТИ", regectPage}
            };
        }
    }
}
