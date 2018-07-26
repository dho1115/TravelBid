using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class VacationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public double? phoneNumber { get; set; }
        public string DreamDestination { get; set; }
        public string DestinationDescription { get; set; }
        public double budget { get; set; }
    }
}
