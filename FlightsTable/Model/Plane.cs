using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsTable.Model
{
    public class Plane
    {
        public int FNum { get; set; }
        public string Airline { get; set; }
        public string City { get; set; }
        public string Terminal { get; set; }
        public int Gate { get; set; }
        public string Status { get; set; }
        public DateTime FlightTime { get; set; }


        public Plane()
        {
            FNum = 0;
            Airline = "0";
            City = "0";
            Terminal = "0";
            Gate = 0;
            Status = "0";
            FlightTime = DateTime.Now;
        }

        public Plane(int FNum, string Airline, string City, string Terminal, int Gate, string Status, DateTime FlightTime)
        {
            this.FNum = FNum;
            this.Airline = Airline;
            this.City = City;
            this.Terminal = Terminal;
            this.Gate = Gate;
            this.Status = Status;
            this.FlightTime = FlightTime;
        }


        public override string ToString()
        {
            return $"|{FNum,5}|{Airline,8}|{City,10}|{Terminal,1}{Gate,2}|{Status,10}|{FlightTime,6:HH:mm}|";
        }
    }
}
