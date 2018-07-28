using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class VacationerModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }        
        public string DreamDestination { get; set; }
        public string DestinationDescription { get; set; }
        public double budget { get; set; }
    }
}
