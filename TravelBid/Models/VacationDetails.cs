using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class VacationDetails
    {
        public int id { get; set; }
        public string DreamDestination { get; set; }
        public string DestinationDescription { get; set; }
        public double budget { get; set; }
        public DestinationRequest DestinationRequestName { get; set; }

        public string VacationDetailsName { get; set; } //Optionally, include a key lookup column here.

        public VacationDetails()
        {

        } 

        public VacationDetails(int ID, string destination, string description, double Budget)
        {
            id = ID;
            DreamDestination = destination;
            DestinationDescription = description;
            budget = Budget;
        }
    } 
}
