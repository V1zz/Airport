using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneLib
{
    class Service
    {

        //Console.WriteLine("Save changes? <Y/N>");
        //ConsoleKeyInfo keys = Console.ReadKey(true);
        //return keys.Key == ConsoleKey.Y ? tmp : plane;
        private bool Check(int count, out int line)
        {
            if (int.TryParse(Console.ReadLine(), out line))
                if (line > -1 & line < count)
                    return true;
            return false;
        }
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

        public int EditorPrinter()
        {
            Console.WriteLine(@"Witch one operation?
    0.Exit
    1.Flight Number
    2.City
    3.Airline 
    4.Trminal and gate
    5.Date and time");
            int i;
            return Check(6, out i) ? i : EditorPrinter();
        }

        public Plane PlaneEditorFnum<T>(T plane) where T : Plane
        {
            Console.Clear();
            Console.WriteLine(plane);
            Console.WriteLine("Changing Flight number!!!");
            Console.Write(plane.FNum + " > ");

            int temp;
            if (int.TryParse(Console.ReadLine(), out temp))
            {
                plane.FNum = temp;
                Console.WriteLine("Reading done!!!");
            }
            else
            {
                Console.WriteLine("Operation failed.");
            }
            return plane;
        }
        
        public string 
    }
}
