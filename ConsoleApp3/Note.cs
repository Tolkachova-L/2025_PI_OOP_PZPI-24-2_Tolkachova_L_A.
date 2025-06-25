using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMin;
        public string Venue;
        public string Info { get; set; }
    }
}
