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
        protected string Airlines { get; set; }
        protected string City { get; set; }
        protected string Terminal { get; set; }
        protected int Gate { get; set; }
        protected string Status { get; set; }
        protected DateTime Time { get; set; }
        protected PlaneType Type { get; set; }
        

        
       



        public override string ToString()
        {
            return $"{FNum,5}{Airlines,10}{City,8}{Terminal,1}{Gate,2}{Status,10}{Time:HH:mm}";
        }
        
    }
}
