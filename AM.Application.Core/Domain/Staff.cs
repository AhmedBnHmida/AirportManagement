﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmployementDate { get; set; }
        public String Function { get; set; }
        public Double Salary { get; set; }
        //methode toString()
        public override string ToString()
        {
            return "EmploymentDate : "+EmployementDate+"\n Function : "+ Function+"\n Salary : "+Salary;
        }
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I'm Staff member");
        }
    }

}
