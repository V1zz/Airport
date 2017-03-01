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
            try
            {
                var planes = new Airport<Departure>
                {
                    new Departure(DateTime.MaxValue),
                    new Departure(DateTime.Now)
                };

                foreach (var plane in planes)
                {
                    Console.WriteLine(plane);
                }

                Service.QSort<Departure>( (Airport<Departure>) planes, 0, planes.Count() - 1)};

                foreach (var plane in planes)
                {
                    Console.WriteLine(plane);
                }

            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
            Console.ReadLine();
            //static void 
        }
    }
}
