using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class DestinationRequest
    { //Let's say a traveler wants to go on MULTIPLE VACATIONS.
        public DestinationRequest() //Constructor.
        {
            this.DestRequests = new HashSet<VacationDetails>(); 
        } 

        //This will have no id.
        public string name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        //This will be added to applicationdbcontext.  

        public ICollection<VacationDetails> DestRequests { get; set; }
    }
}
