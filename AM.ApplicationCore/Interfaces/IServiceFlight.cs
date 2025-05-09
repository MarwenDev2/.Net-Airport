using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight:IService<Flight>
    {
        IList<Staff> GetStaff(int id);

        IList<Traveller> GetTravellersByFlightAndDate(int planeId, DateTime flightDate);

        void DisplayNbreTraveller(DateTime date1, DateTime date2);

        public IEnumerable<Flight> SortFlights();
    }
}
