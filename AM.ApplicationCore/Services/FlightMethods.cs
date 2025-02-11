using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        Action FlightDetailsDel;

        public List<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> dates = new List<DateTime>();
            //for (int i = 0; i < TestData.listFlights.Count; i++)
            //{
            //    if (TestData.listFlights[i].Destination == destination)
            //        dates.Add(TestData.listFlights[i].FlightDate);
            //}
            //return dates;

            //Avec langage LINQ :
            var req = from flight in Flights
                      where flight.Destination == destination
                      select flight.FlightDate;

            //expression Lamda :
            var lamdareq = Flights.Where(f=> f.Destination == destination).Select(f => f.FlightDate);

            return req.ToList();
        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> flights = new List<Flight>();

            for (int i = 0; i < TestData.listFlights.Count; i++)
            {
                switch (filterType.ToLower())
                {
                    case "departure":
                        if (TestData.listFlights[i].Departure == filterValue)
                            flights.Add(TestData.listFlights[i]);
                        break;
                    case "destination":
                        if (TestData.listFlights[i].Destination == filterValue)
                            flights.Add(TestData.listFlights[i]);
                        break;
                    case "effectivearrival":
                        if (TestData.listFlights[i].EffectiveArrival == DateTime.Parse(filterValue))
                            flights.Add(TestData.listFlights[i]);
                        break;
                    case "estimatedduration":
                        if (TestData.listFlights[i].EstimatedDuration == float.Parse(filterValue))
                            flights.Add(TestData.listFlights[i]);
                        break;
                    case "flightdate":
                        if (TestData.listFlights[i].FlightDate == DateTime.Parse(filterValue))
                            flights.Add(TestData.listFlights[i]);
                        break;
                    case "flightid":
                        if (TestData.listFlights[i].FlightId == int.Parse(filterValue))
                            flights.Add(TestData.listFlights[i]);
                        break;
                }

            }
            return flights;

        }

        public void ShowFlightDetails(Plane plane)
        {
            var req = from flight in Flights
                      where flight.Plane.Equals(plane)
                      select flight;
            foreach (var flight in req)
                Console.WriteLine("\nDestination : "+flight.Destination + " and flight Date : " +flight.FlightDate);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            int nb = 0;
            var req = from flight in Flights
                      where flight.FlightDate.Date < (startDate.Date.AddDays(7)) &&
                      flight.FlightDate.Date > (startDate.Date)
                      select flight;
            //foreach (var flight in req)
            //        nb++;
            return req.Count();

            //expression Lamda :
            Flights.Count(f => f.FlightDate.Date > startDate.Date && f.FlightDate.Date < startDate.Date.AddDays(7));
        }

        public float DurationAverage(string destination)
        {
            var req = from flight in Flights
                      where flight.Destination == destination
                      select flight.EstimatedDuration;
            return req.Average();


            //expression Lamda :
            Flights.Where(f => f.Destination == destination)
                   .Select(f => f.EstimatedDuration)
                   .Average();
        }

        public List<Flight> OrderedDurationFlights()
        {
            var req = from flight in Flights
                      orderby flight.EstimatedDuration descending
                      select flight;
            return req.ToList();


            //expression Lamda :
            Flights.OrderByDescending(f => f.EstimatedDuration).ToList();
        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            var req = from p in flight.Passengers.OfType<Traveller>()
                      orderby p.BirthDate
                      select p;
            return req.Take(3 ).ToList();

            //expression Lamda :
            flight.Passengers.OfType<Traveller>()
                             .OrderBy(p => p.BirthDate)
                             .Take(3)
                             .ToList();
        }

        public void DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine("\n Destination : " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("\n Décollage : " + f.FlightDate);
            }

            //expression Lamda :
            Flights.GroupBy(f => f.Destination)
                   .ToList()
                   .ForEach(g =>
                   {
                       Console.WriteLine($"\nDestination: {g.Key}");
                       g.ToList().ForEach(f => Console.WriteLine($"\nDécollage: {f.FlightDate}"));
                   });
        }
    }
}
