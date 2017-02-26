using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PlaneLib
{
    public class Departure : Plane
    {
        public Departure(DateTime time) : base()
        {
            this.Time = time;
            Type = PlaneType.Departure;
        }

        public Departure()
        {
            
        }
    }
}
