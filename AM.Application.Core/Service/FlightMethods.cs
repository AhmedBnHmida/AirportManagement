using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;


namespace AM.ApplicationCore.Service
{
    public class FlightMethods:IFlightMethods
    {
        public List<Flight> Flights = new List<Flight>();



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
            List<DateTime> dates = new List<DateTime> ();
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


    }
}
