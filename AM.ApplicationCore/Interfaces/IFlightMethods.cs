﻿using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);

        List<Flight> GetFlights(string filterType, string filterValue);

        void ShowFlightDetails(Plane plane);

        int ProgrammedFlightNumber(DateTime startDate);

        float DurationAverage(string destination);

        List<Flight> OrderedDurationFlights();

        //List<Traveller> SeniorTravellers(Flight flight);

        void DestinationGroupedFlights();

    }
}
