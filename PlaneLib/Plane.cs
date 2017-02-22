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
        protected internal DateTime Time { get; set; }
        public PlaneType Type { get; set; }
        

        
       



        public override string ToString()
        {
            return $"{FNum,5}{Airlines,10}{City,8}{Terminal,1}{Gate,2}{Status,10}{Time:HH:mm}";
        }
        
    }
}
