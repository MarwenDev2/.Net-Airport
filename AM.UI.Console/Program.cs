using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System;

// Create Plane using constructor
Plane plane = new Plane(300, DateTime.Now, PlaneType.Boeing)
{
    PlaneId = 1
};

Console.WriteLine(plane.ToString());

// Create another Plane using object initializer
Plane plane2 = new Plane
{
    Capacity = 300,
    ManufactureDate = DateTime.Now,
    PlaneType = PlaneType.Boeing
};

// Create a Passenger with FullName
Passenger p1 = new Passenger
{
    BirthDate = new DateTime(2001, 2, 26),
    EmailAddress = "marwenfeki214@gmail.com",
    PasseportNumber = "0192393",
    TelNumber = "52423987",
    FullName = new FullName
    {
        FirstName = "Marwen",
        LastName = "Feki"
    }
};

// Test CheckProfile and PassengerType methods
Console.WriteLine(p1.CheckProfile("Oussema", "Feki", "Helllooo"));
Console.WriteLine(p1.PassengerType());

// Create a Traveller with FullName
Traveller t1 = new Traveller
{
    BirthDate = new DateTime(2001, 2, 26),
    EmailAddress = "marwenfeki214@gmail.com",
    PasseportNumber = "0192393",
    TelNumber = "52423987",
    HealthInformation = "Healthy, Non-Smoker",
    Nationality = "Tunisian",
    FullName = new FullName
    {
        FirstName = "Marwen",
        LastName = "Feki"
    }
};

Console.WriteLine(t1.PassengerType());

// Create a Staff Member with FullName
Staff s1 = new Staff
{
    BirthDate = new DateTime(2001, 2, 26),
    EmailAddress = "marwenfeki214@gmail.com",
    PasseportNumber = "0192393",
    TelNumber = "52423987",
    EmployementDate = new DateTime(2019, 4, 26),
    Function = "Manager",
    Salary = 2000,
    FullName = new FullName
    {
        FirstName = "Marwen",
        LastName = "Feki"
    }
};

Console.WriteLine(s1.PassengerType());

// Initialize FlightMethods with test data
FlightMethods fm = new FlightMethods
{
    Flights = TestData.listFlights
};

// Display flight dates for a specific destination
Console.WriteLine("\nListe des flights vers Paris : \n");
foreach (var f in fm.GetFlightDates("Paris"))
    Console.WriteLine(f);

// Filter flights by estimated duration
Console.WriteLine("\nListe des flights avec une durée estimée de 105 minutes : \n");
foreach (var f in fm.GetFlights("estimatedDuration", "105"))
    Console.WriteLine(f);

// Display flight details for a specific plane
fm.ShowFlightDetails(TestData.BoingPlane);

// Get the number of flights in a week starting from a given date
DateTime d1 = new DateTime(2022, 03, 28);
Console.WriteLine($"\nIl y a {fm.ProgrammedFlightNumber(d1)} vols programmés à partir du : {d1.Date}");

// Get the average duration for flights to a given destination
Console.WriteLine($"\nLa durée moyenne des vols vers Madrid est : {fm.DurationAverage("Madrid")} minutes");

// Display ordered flights by estimated duration
Console.WriteLine("\nVols triés par durée estimée :");
foreach (var flight in fm.OrderedDurationFlights())
{
    Console.WriteLine($"\nPlane: {flight.Plane.PlaneType}, Destination: {flight.Destination}, Estimated Duration: {flight.EstimatedDuration} minutes");
}

// Display the 3 oldest travellers on a specific flight
//Console.WriteLine("\nTop 3 Senior Travellers:");
//foreach (var traveller in fm.SeniorTravellers(TestData.flight1))
//    Console.WriteLine(traveller.ToString());

// Group flights by destination
fm.DestinationGroupedFlights();

// Display passenger information before transformation
Console.WriteLine("\nAvant la transformation : " + p1.ToString());

// Convert Passenger's full name to uppercase (assuming you implemented UpperFullName method)
p1.FullName.FirstName = p1.FullName.FirstName.ToUpper();
p1.FullName.LastName = p1.FullName.LastName.ToUpper();

Console.WriteLine("\nAprès la transformation : " + p1.ToString());

// Save a flight to the database using AMContext
AMContext context = new AMContext();

//context.Flights.Add(TestData.flight2);
//context.SaveChanges();
Console.WriteLine("\nFlight saved successfully to the database.");

Console.WriteLine("\nPlane Capacity: {context.Flights.First().Plane.Capacity}");