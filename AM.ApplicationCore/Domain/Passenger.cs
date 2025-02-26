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
        [Display(Name ="DateOnly of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [MinLength(3,ErrorMessage ="Lenght have to be at least 3 Letters"), 
            MaxLength(25, ErrorMessage = "Lenght have to be at least 3 Letters")]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "Lenght have to be at least 3 Letters")]
        [MaxLength(25, ErrorMessage = "Lenght have to be lower than 25 letters")]
        public string LastName { get; set; }
        [Key, StringLength(7)]
        public string PasseportNumber { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
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
