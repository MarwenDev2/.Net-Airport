using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Plane plane = new Plane(300,DateTime.Now,PlaneType.Boeing);
plane.PlaneId = 1;

Console.WriteLine(plane.ToString());

Plane plane2 = new Plane
{
    Capacity = 300 ,
    ManufactureDate = DateTime.Now,
    PlaneType = PlaneType.Boeing
};
Passenger p1 = new Passenger
{
    BirthDate = new DateTime(2001, 2, 26),
    EmailAddress = "marwenfeki214@gmail.com",
    FirstName = "marwen",
    LastName = "feki",
    PasseportNumber = "0192393",
    TelNumber = "52423987"
};

Console.WriteLine(p1.CheckProfile("Oussema", "Feki", "Helllooo"));
Console.WriteLine(p1.PassengerType());

Traveller t1 = new Traveller
{
    BirthDate = new DateTime(2001, 2, 26),
    EmailAddress = "marwenfeki214@gmail.com",
    FirstName = "Marwen",
    LastName = "Feki",
    PasseportNumber = "0192393",
    TelNumber = "52423987",
    HealthInformation= "Healthy , Non Smoker",
    Nationality = "Tunisien"
};

Console.WriteLine(t1.PassengerType());

Staff s1 = new Staff
{
    BirthDate = new DateTime(2001, 2, 26),
    EmailAddress = "marwenfeki214@gmail.com",
    FirstName = "Marwen",
    LastName = "Feki",
    PasseportNumber = "0192393",
    TelNumber = "52423987",
    EmployementDate = new DateTime(2019, 4, 26),
    Function = "Manager",
    Salary = 2000
};

Console.WriteLine(s1.PassengerType());

FlightMethods fm = new FlightMethods
{
    Flights = TestData.listFlights
};
Console.WriteLine("\n Liste des flights du Paris : \n");
foreach (var f in fm.GetFlightDates("Paris"))
    Console.WriteLine(f);

Console.WriteLine("\n Liste des flights du Customized : \n");
foreach (var f in fm.GetFlights("estimatedDuration","105"))
    Console.WriteLine(f);
fm.ShowFlightDetails(TestData.BoingPlane);

DateTime d1 = new DateTime(2022, 03, 28);

Console.WriteLine("\nThere are "+fm.ProgrammedFlightNumber(d1) +" Programmed flights in the week starting from : " + d1.Date);

Console.WriteLine("\nThe estimated duration for the flights going to Paris is  " + fm.DurationAverage("Madrid"));

foreach (var flight in fm.OrderedDurationFlights())
{
    Console.WriteLine($"\n Plance: {flight.Plane.PlaneType}, Destination: {flight.Destination}, Estimated Duration: {flight.EstimatedDuration} minutes");
}

foreach(var i in fm.SeniorTravellers(TestData.flight1))
    Console.WriteLine(i.ToString());

fm.DestinationGroupedFlights();

Console.WriteLine("Before : " + p1.ToString());

p1.UpperFullName();

Console.WriteLine("Later : " + p1.ToString());

AMContext context =  new AMContext();
context.Flights.Add(TestData.flight2);
context.SaveChanges();