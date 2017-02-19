using System;
using System.Collections.Generic;
using FlightsTable.Model;

namespace FlightsTable.Dep
{
    public class MainClass
    {
        private List<Plane> _arrival;
        private List<Plane> _departure;

        public MainClass()
        {
            _arrival = new List<Plane>();
            _departure = new List<Plane>();
        }


    }
}