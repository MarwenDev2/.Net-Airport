using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
    [PrimaryKey("PasseportNumber", "FlightId")]
    public class Ticket
    {

        public double Price { get; set; }

        public int Seat { get; set; }

        public bool VIP { get; set; }

        // Foreign Keys
        public string PasseportNumber { get; set; }
        public int FlightId { get; set; } 

        // Navigation Properties
        [ForeignKey("PasseportNumber")]
        public virtual Passenger MyPassenger { get; set; }

        [ForeignKey("FlightId")]
        public virtual Flight MyFlight { get; set; }
    }
}
