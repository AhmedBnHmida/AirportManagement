// See https://aka.ms/new-console-template for more information
using System.Numerics;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Service;
using Plane = AM.ApplicationCore.Domain.Plane;



Console.WriteLine("Hello, World!");

//Plane p1 = new Plane(12,new DateTime(2025,09,24),4,PlaneType.Boing);
Plane p1 = new Plane
{
    Capacity = 12,
    ManufactureDate = new DateTime(2025, 09, 24),
    PlaneId = 4,
    PlaneType = PlaneType.Boing,
};
Console.WriteLine(p1);
Passenger p2 = new Passenger
{
    FirstName = "ahmed",
    LastName = "benhmida",
};
Console.WriteLine("\n**********Test CheckProfile 1*******");
Console.WriteLine(p2.CheckProfile("benhmida", "ahmed"));
Passenger p3 = new Passenger
{
    FirstName = "ahmed",
    LastName = "benhmida",
    EmailAddress = "ahmed.benhmida@esprit.tn"
};

Console.WriteLine("\n**********Test CheckProfile 2*******");

Console.WriteLine(p3.CheckProfile("benhmida", "ahmed", "ahmed.benhmida@esprit.tn"));
p3.PassengerType();
Staff s = new Staff
{
    FirstName = "ahmed"
};
Console.WriteLine("\n**********Test passengertype staff*******");
s.PassengerType();
Traveller t = new Traveller
{
    FirstName = "benhmida"
};
Console.WriteLine("\n**********Test passengertype traveller*******");
t.PassengerType();
Console.WriteLine("\n**********Test GetFlightDates*******");

FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
foreach (var item in fm.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}
Console.WriteLine("\n**********Test GetFlights*******");

