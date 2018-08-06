using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class TravelAgentParameters
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int yearsexperience { get; set; }
        public string ASTACertified { get; set; }
        public string Specialties { get; set; }
        public string PlacesVisited { get; set; }
        public string email { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
