using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaneLib;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = new Airport<Plane>();
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        //static void 
    }
}
