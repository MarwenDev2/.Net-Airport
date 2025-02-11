using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasseportNumber { get; set; }
        public string TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public bool CheckProfile(string firstName, string lastName , string email)
        {
            if(email != null)
                return FirstName == firstName && LastName.Equals(lastName) && EmailAddress == email;
            else if(email == null)
                return FirstName == firstName && LastName.Equals(lastName);
            else return false;
        }

        public virtual string PassengerType()
        {
            return " I am a Passenger !";
        }

        public override string ToString()
        {
            return $"Passenger: {FirstName} {LastName}, Passport: {PasseportNumber}, Email: {EmailAddress}, Phone: {TelNumber}, BirthDate: {BirthDate.ToShortDateString()}";
        }
    }
}
