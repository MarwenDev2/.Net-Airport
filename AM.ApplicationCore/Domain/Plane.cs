﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boeing, Airbus}
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public Plane(int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }

        public Plane()
        {
        }

        public override string? ToString()
        {
            return " Capacity : " + Capacity + " ManufactureDate : " + ManufactureDate + " PlaneId : " + PlaneId + " PlaneType : " + PlaneType;
        }
    }
}
