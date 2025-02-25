using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;


namespace AM.ApplicationCore.Service
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights = new List<Flight>();

        public List<Flight> FlightsVide = new List<Flight>();


        //Avec for

        //List<DateTime> IFlightMethods.GetFlightDates(string destination)
        //{
        //    List<DateTime> dates = new List<DateTime>();
        //    for (int i = 0; i < Flights.Count; i++)
        //    {
        //        if (Flights[i].Destination == destination)
        //            dates.Add(Flights[i].FlightDate);
        //    }
        //    return dates;
        //}



        //Avec ForEach
        /*
        List<DateTime> IFlightMethods.GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            foreach (Flight i in Flights)

            {
                if (i.Destination == destination)
                    dates.Add(i.FlightDate);
            }
            return dates;
        }
        */


        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            //for(int i = 0; i < Flights.Count; i++)
            //foreach (Flight i in Flights) 

            //{
            //    if (i.Destination == destination)
            //        dates.Add(i.FlightDate);
            //}
            //return dates;

            //***********LINQ
            var query = from f in Flights
                        where f.Destination == destination
                        select f.FlightDate;
            return query.ToList();

        }

        public void GetFlights(string filterType, string filterValue)
        {
            List<Flight> result = new List<Flight>();
            foreach (Flight i in Flights)
            {
                switch (filterType)
                {
                    case "Departure":
                        if (i.Departure == filterValue)
                            Console.WriteLine(i);
                        break;
                    case "Destination":
                        if (i.Destination == filterValue)
                            Console.WriteLine(i);
                        break;
                    case "EffectiveArrival":
                        if (i.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(i);
                        break;
                    case "EstimatedDuration":
                        if (i.EstimatedDuration == int.Parse(filterValue))
                            Console.WriteLine(i);
                        break;
                    case "FlightDate":
                        if (i.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(i);
                        break;
                    default:
                        Console.WriteLine("Default");
                        break;
                }
            }

        }

        /*

        //10
        public void ShowFlightDetails(Plane plane)
        {
            var flightDetails = from flight in Flights
                                where flight.Plane == plane
                                select new { flight.FlightDate, flight.Destination };

            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Date: {detail.FlightDate}, Destination: {detail.Destination}");
            }
        }

        //11
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(7);
            var flightCount = Flights.Count(flight => flight.FlightDate >= startDate && flight.FlightDate <= endDate);
            return flightCount;
        }

        //12
        public double DurationAverage(string destination)
        {
            var flights = Flights.Where(flight => flight.Destination == destination).ToList();
            if (flights.Any())
            {
                double averageDuration = flights.Average(flight => flight.EstimatedDuration);
                return averageDuration;
            }
            else
            {
                return 0; // Si aucun vol trouvé pour la destination
            }
        }
        //13
        public List<Flight> OrderedDurationFlights()
        {
            var orderedFlights = Flights.OrderByDescending(flight => flight.EstimatedDuration).ToList();
            return orderedFlights;
        }

        //14
        public List<Traveller> SeniorTravellers(Flight flight)
        {
            var seniorTravellers = flight.Passengers.OfType<Traveller>()
                                                    .OrderByDescending(traveller => traveller.Age)
                                                    .Take(3)
                                                    .ToList();
            return seniorTravellers;
        }
        */


        public void ShowFlightDetails(Domain.Plane plane)
        {
            //Avec Linq

            //var req = from f in Flights
            //          where f.plane == plane
            //          select new { f.Destination, f.FlightDate };
            //foreach (var q in req)
            //{
            //    Console.WriteLine(q.ToString());
            //}

            //Avec Lamda

            var req = Flights.Where(f => f.Plane == plane).Select(f => new { f.Destination, f.FlightDate });
            foreach (var q in req)
            {
                Console.WriteLine(q.ToString());
            }

        }



        public int ProgrammedFlightNumber(DateTime startDate)
        {

            var query = from f in Flights
                        where DateTime.Compare(startDate, f.FlightDate) <= 0
                        && (f.FlightDate - startDate).TotalDays <= 7
                        select f;
            return query.Count();


        }


        public double DurationAverage(string destination)

        //Avec Linq
        {
            //var query = from flight in Flights
            //            where flight.Destination == destination
            //            select flight.EstimatedDuration;
            //            return query.Average();

            //Avec Lamda

            return Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).Average();

        }


        public IEnumerable<Flight> OrderedDurationFlights()
        {// Avec Linq

            //var query = from f in Flights
            //            orderby f.EstimatedDuration descending
            //            select f;
            //return query;

            //Avec Lamda

            return Flights.OrderByDescending(f => f.EstimatedDuration);


        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {

            // Avec Linq

            //var req = from f in flight.Passengers.OfType<Traveller>()
            //          orderby f.BrithDate ascending
            //          select f;
            //return req.Take(3);

            //Avec Lamda

            return flight.Passengers.OfType<Traveller>().OrderBy(f => f.BirthDate).Take(3);

        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupFlihghts()
        {
            var req = from f in Flights
                      group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine(g.Key);
                foreach (var v in g)

                    Console.WriteLine("Décollage : " + v.FlightDate);
            }
            return req;
        }
    }


}
