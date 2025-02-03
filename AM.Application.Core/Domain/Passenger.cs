using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Core.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string TelNumber { get; set; }
        public String PassportNumber { get; set; }

        public IList<Flight> flights { get; set; }

        public override string ToString()
        {
            return "BirthDate : " + BirthDate
                + " EmailAddress : " + EmailAddress
                + " FirstName : " + FirstName
                + " LastName : " + LastName
                + " PassportNumber : " + PassportNumber
                + " TelNumber : " + TelNumber
                + " id " + Id;
        }

        public bool checkProfile(string nom,string prenom)
        {
            return nom==LastName && prenom== FirstName;
        }
        public bool checkProfile(string nom, string prenom,string email)
        {
            return nom == LastName && prenom == FirstName && email.Equals(EmailAddress);
        }
        public bool checkProfile1(string nom, string prenom, string email=null)
        {
            if (email==null )
                return nom == LastName && prenom == FirstName;
            return nom == FirstName && prenom == LastName && email.Equals(EmailAddress);
        }

    }
}
