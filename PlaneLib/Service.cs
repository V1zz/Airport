using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneLib
{
    class Service
    {
        protected virtual PlaneType GetPlaneType()
        {
            int temp;
            while (true)
            {
                Console.WriteLine(@"Take a choise
    1. Arrival
    2. Departure");
                if (!int.TryParse(Console.ReadLine(), out temp)) continue;

                return temp == 2 ? PlaneType.Departure : PlaneType.Arrival;
            }
        }

        public Plane PlaneEditor<T>(T plane) where T : Plane
        {
            var tmp = plane;
            while (true)
            {
                break;
            }
            Console.WriteLine("Save changes? <Y/N>");
            ConsoleKeyInfo keys = Console.ReadKey(true);
            return keys.Key == ConsoleKey.Y ? tmp : plane;
        }

    }
}
