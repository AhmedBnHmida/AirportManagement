using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Core.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public String Function { get; set; }
        public Double Salary { get; set; }
    }
}
