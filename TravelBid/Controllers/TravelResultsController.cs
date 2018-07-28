using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBid.Models;

namespace TravelBid.Controllers
{
    public class TravelResultsController : Controller
    {
       public IActionResult Index(string BackToTravelResults)
       {
            List<VacationSuggestions> PlacesToGo = new List<VacationSuggestions>();            

            if (string.IsNullOrEmpty(BackToTravelResults))
            {
                Console.WriteLine("return current popular destinations");

                PlacesToGo.Add(new VacationSuggestions
                {
                    DestinationName = "Las Vegas",
                    Attractions = "Cirque Du Soleil, Comedy shows, BUFFETS!!!",
                    BestTimeToGo = "Winter"
                });

                PlacesToGo.Add(new VacationSuggestions
                {
                    DestinationName = "Reno",
                    Attractions = "Lake Tahoe, Virginia City, Skiiing",
                    BestTimeToGo = "Fall"                
                });

                PlacesToGo.Add(new VacationSuggestions
                {
                    DestinationName = "Costa Rica",
                    Attractions = "Cloud Forest, Nightlife, Beaches",
                    BestTimeToGo = "Mid December to April"
                });

                PlacesToGo.Add(new VacationSuggestions
                {
                    DestinationName = "Hong Kong",
                    Attractions = "Shopping, Symphony of light dinner cruise, Hong Kong Disneyland",
                    BestTimeToGo = "October to December"
                });

                PlacesToGo.Add(new VacationSuggestions
                {
                    DestinationName = "South Beach",
                    Attractions = "FOOD!!!, Beach, Walk down Ocean Drive",
                    BestTimeToGo = "Fall"
                });
         
            } 

            else if(BackToTravelResults.ToLowerInvariant() == "Las Vegas")
            {
                PlacesToGo.Add(new VacationSuggestions
                {
                    DestinationName = "Las Vegas",
                    Attractions = "Cirque Du Soleil, Comedy shows, BUFFETS!!!",
                    BestTimeToGo = "Winter"
                });                
            } 

            else if(BackToTravelResults.ToLowerInvariant() == "Reno")
            {
                PlacesToGo.Add(new VacationSuggestions
                {
                    DestinationName = "Reno",
                    Attractions = "Lake Tahoe, Virginia City, Skiing",
                    BestTimeToGo = "Fall"
                });
            };
            
            return View(PlacesToGo);
       }

        List<VacationerModel> Vacationer = new List<VacationerModel>();
        
        public IActionResult NewTravelRequest(string CustomerFirstName, string CustomerLastName, string Email, string destination, double maxbudget, string additionalInfo)
        {
            //ViewData["customer"] = customername;
            Vacationer.Add(new VacationerModel { FirstName = CustomerFirstName  });
            Vacationer.Add(new VacationerModel { LastName = CustomerLastName });
            Vacationer.Add(new VacationerModel { email = Email });
            Vacationer.Add(new VacationerModel { DreamDestination = destination });
            Vacationer.Add(new VacationerModel { budget = maxbudget });
            Vacationer.Add(new VacationerModel { DestinationDescription = additionalInfo });

            return View(Vacationer);
        }
        
    }
}