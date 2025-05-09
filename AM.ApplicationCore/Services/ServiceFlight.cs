using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        IUnitOfWork UnitOfWork ;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        public IList<Staff> GetStaff(int id)
        {
            return GetById(id)
                .Tickets
                .Select(t=>t.MyPassenger)
                .OfType<Staff>().ToList();
        }
        public IList<Traveller> GetTravellersByFlightAndDate(int planeId, DateTime flightDate)
        {
            return GetMany(f => f.Plane.PlaneId == planeId && f.FlightDate.Date == flightDate.Date)
                .SelectMany(f => f.Tickets)
                .Select(t => t.MyPassenger)
                .OfType<Traveller>()
                .ToList();
        }

        public void DisplayNbreTraveller(DateTime date1, DateTime date2)
        {
            var req = GetMany(f => f.FlightDate <= date1 && f.FlightDate <= date2)
                .SelectMany(f => f.Tickets)
                .GroupBy(t => t.MyFlight.FlightDate)
                .Select(t => new { group = t.Key, count = t.Count() });
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }
    }
}
