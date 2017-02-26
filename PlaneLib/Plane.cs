using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneLib
{
    public abstract class Plane
    {
        public int FNum { get; set; }
        protected internal string Airlines { get; set; }
        protected internal string City { get; set; }
        protected internal string Terminal { get; set; }
        protected internal int Gate { get; set; }
        protected internal string Status { get; set; }
        public DateTime Time { get; set; }
        public PlaneType Type { get; set; }

        public Plane()
        {
            Airlines = "0";
            City = "0";
            Terminal = "0";
            Status = "0";

        }





        public override string ToString()
        {
            return $"{FNum,5}{Airlines,10}{City,8}{Terminal,1}{Gate,2}{Status,10}{Time:HH:mm}";
        }
        
    }
}
