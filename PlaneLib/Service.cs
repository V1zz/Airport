using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PlaneLib
{
    public class Service
    {
        /*protected virtual PlaneType GetPlaneType()
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
               }*/
        //Console.WriteLine("Save changes? <Y/N>");
        //ConsoleKeyInfo keys = Console.ReadKey(true);
        //return keys.Key == ConsoleKey.Y ? tmp : plane;C:\Users\chuma\onedrive\документы\visual studio 2015\Projects\AirportNew\PlaneLib\Airport.cs
        private bool Check(int count, out int line)
        {
            if (int.TryParse(Console.ReadLine(), out line))
                if (line > -1 & line < count)
                    return true;
            return false;
        }
       
        protected internal int EditorPrinter()
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

        protected internal  Plane EditFnumPlane<T>(T plane) where T : Plane
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

        protected internal  Plane EditCityPlane<T>(T plane) where T : Plane
        {
            Console.Clear();
            Console.WriteLine(plane);
            Console.WriteLine("Changing City/Port");
            Console.Write(plane.City + " > ");

            var tmp = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(tmp))
                plane.City = tmp;

            return plane;
        }

        protected internal Plane EditAirlinePlane<T>(T plane) where T : Plane
        {
            Console.Clear();
            Console.WriteLine(plane);
            Console.WriteLine("Changing Airline");
            Console.Write(plane.City + " > ");

            var tmp = Console.ReadLine() as string;
            if (tmp != null)
                plane.Airlines = tmp;

            return plane;
        }

        protected internal Plane EditTermGate<T>(T plane) where T : Plane, new()
        {
            var temp = new T();
            temp = plane;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(temp);
                Console.WriteLine("Changing Terminal/Gate value");
                Console.WriteLine(temp.Terminal + " > ");

                var rdr = Console.ReadLine();

                var pattern = @"^(([A-Z])([0-9]){2})$";
                Match match = Regex.Match(rdr, pattern);
                if (!match.Success) continue;

                try
                {
                    temp.Terminal = rdr.Substring(0, 0);
                    temp.Gate = int.Parse(rdr.Substring(1, 2));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                break;
            }

            Console.WriteLine("Save changes? <Y/N>");
            ConsoleKeyInfo keys = Console.ReadKey(true);
            return keys.Key == ConsoleKey.Y ? temp : plane;
        }

        public static void QSort<T>(T[] planes, int fist, int last) where T : Plane//, new()
        {
            if (planes.Length <= 1)
                return;
            int i = fist,
                j = last;
            var x = planes[fist + (last - fist)/2];
            while (i <= j)
            {
                while (planes[i].Time < x.Time)
                    i++;
                while (planes[j].Time > x.Time)
                    j--;
                if (i <= j)
                {
                    var tmp = planes[i];
                    planes[i] = planes[j];
                    planes[j] = tmp;
                    i++;
                    j--;
                }
            }
            if (i < fist)
                QSort(planes, i, last);
            if (fist < last)
                QSort(planes, fist, j);
        }

    //    public static T[] ConvertTo<T>(T[] planes) where T : Plane, new()
    //    {
    //        var tmp = new T[];
    //        if (planes.Length <= 1)
    //            return tmp;
    //        foreach (var t in planes)
    //        {
    //            tmp.Add(t);
    //        }
    //        return tmp;
    //    }
    }
}
