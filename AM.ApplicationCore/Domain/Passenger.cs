using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int id {  get; set; }
        public FullName FullName { get; set; }

        [Display(Name ="DateOnly of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
        [Key, StringLength(7)]
        public string PasseportNumber { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public string TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
            else
                return FullName.FirstName == firstName && FullName.LastName == lastName;
        }

        public virtual string PassengerType()
        {
            return " I am a Passenger !";
        }

        public override string ToString()
        {
            return $"Passenger: {FullName.FirstName} {FullName.LastName}, Passport: {PasseportNumber}, Email: {EmailAddress}, Phone: {TelNumber}, BirthDate: {BirthDate.ToShortDateString()}";
        }
    }
}
