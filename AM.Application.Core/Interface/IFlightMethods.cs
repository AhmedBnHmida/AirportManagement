using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interface
{
    public interface IFlightMethods
    {
        public List<DateTime> GetFlightDates(string destination);
        public void GetFlights(string filterType, string filterValue);
    }
}
