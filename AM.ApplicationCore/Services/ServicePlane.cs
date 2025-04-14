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
    }
}
