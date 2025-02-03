using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Core.Domain
{
    public class Flight
    {
        public String Departure { get; set; }
        public String Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EsstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public Plane plane { get; set; }
        public ICollection<Passenger> passengers { get; set; }
    }
}
