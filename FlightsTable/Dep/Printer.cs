using System;
using System.Collections.Generic;
using FlightsTable.Model;

namespace FlightsTable.Dep
{
    public class Printer
    {
        private void PrintList(List<Plane> plane)
        {
            foreach (var v in plane)
            {
                Console.WriteLine(v);
            }
        }
    }
}