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
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public ICollection<VacationModelVacationCart> VacationModelVacationCarts //This is the naming convention when you JOIN two products/services. Here, the ICollection serves as the JOIN. => Joins Vacation Model and Vacation Cart.
        
        public VacationModel()
        {
            //This is the constructor for the above "ICollection". The "this" (below) refers to the VacationModelVacationCarts.

            this.VacationModelVacationCarts = new HashSet<VacationModelVacationCart>(); 
        }

        public string VacationerModelFK { get; set; } //This is the foreign key that will serve as the link to the cart.
    }
}
