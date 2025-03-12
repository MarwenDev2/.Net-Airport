using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        public static void UpperFullName(this Passenger p)
        {
            if (p.FullName != null)
            {
                p.FullName.FirstName = char.ToUpper(p.FullName.FirstName[0]) + p.FullName.FirstName.Substring(1).ToLower();
                p.FullName.LastName = char.ToUpper(p.FullName.LastName[0]) + p.FullName.LastName.Substring(1).ToLower();
            }
        }
    }
}
