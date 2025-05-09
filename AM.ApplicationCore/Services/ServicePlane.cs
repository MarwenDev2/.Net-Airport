using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        IUnitOfWork UnitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IList<Traveller> GetTravellers(Plane plane)
        {
            return GetById(plane.PlaneId)
                .Flights
                .SelectMany(f => f.Tickets)
                .Select(t => t.MyPassenger).OfType<Traveller>()
                .ToList();
        }

        IList<Flight> IServicePlane.GetFlights(int n)
        {
            return GetAll().
                OrderByDescending(p=>p.PlaneId)
                .Take(n).
                SelectMany(p=>p.Flights)
                .ToList();
        }

        public bool AvailablePlanes(int n, Flight flight)
        {
            return GetAll()
                .Where(p => p.Flights.Count() < n)
                .Any(p => p.Flights
                    .Any(f => f.Departure == flight.Departure && f.Destination == flight.Destination));
        }

        public void DeleteOldPlanes()
        {
            var oldPlanes = GetMany(p=> DateTime.Now.Year - p.ManufactureDate.Year > 10);

            foreach (var plane in oldPlanes)
            {
                Delete(plane);
                Commit();
            }
        }
    }
}
