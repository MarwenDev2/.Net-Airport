﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string? AirlineLogo { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public int PlaneId { get; set; }
        [ForeignKey("PlaneId")]
        public virtual Plane Plane { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string? ToString()
        {
            return " Departure : " + Departure + " Destination : " + Destination + " EffectiveArrival : " + EffectiveArrival + " EstimatedDuration : " + EstimatedDuration + " FlightDate : " + FlightDate;
        }
    }
}
