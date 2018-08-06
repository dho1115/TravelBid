using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBid.Models;

namespace TravelBid.Models
{
    public class CombinedInfoVacationer
    {
        public PersonalInfoVacationer Traveler { get; set; }
        public VacationDetails vacationdetails { get; set; }
    }
}
