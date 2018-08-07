using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class DestinationRequest
    {
        //This will have no id.
        public string name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        //This will be added to applicationdbcontext.       
    }
}
