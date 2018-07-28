using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class VacationSuggestions
    {
        public int ID { get; set; }
        public string DestinationName { get; set; }
        public string Attractions { get; set; }
        public string BestTimeToGo { get; set; }
    }
}
