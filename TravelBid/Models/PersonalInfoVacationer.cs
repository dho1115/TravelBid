using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class PersonalInfoVacationer
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }

        public PersonalInfoVacationer()
        {

        } 

        public PersonalInfoVacationer(int ID, string fn, string ln, string EMail)
        {
            id = ID;
            FirstName = fn;
            LastName = ln;
            email = EMail;
        }
    }
}
