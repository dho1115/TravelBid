using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBid.Models;

namespace TravelBid.Controllers
{
    public class TravelResultsController : Controller
    {      
        //SIDE NOTE: For now (8/2/18 @ 11:36am), we will ENTER the results via a SQL Query Server(new query) and then retrieve it via the "While" code below.

        public IActionResult Index(string BackToTravelResults)
       {
            //Notice below the data is "Hard coded" (Las Vegas, Comedy shows, etc...). What if I ran a SELECT... FROM. I need to open a connection, run a query and convert it.

            //GO TO NUGET.

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=David;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

           System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);

           connection.Open();

           connection.Close();

            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();

            //command.CommandText = "Select top 1 where book id = " + ;

            System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();

            //BeachProduct model = new BeachProduct();

            VacationSuggestions newdestination = new VacationSuggestions();

            command.CommandText = "Select top 1 where book id = " + newdestination.ID;

            //Names of the columns (idPosition, titlePosition, imagePathPosition, etc...) were all the Model property names taken from (in the example case) Beach product:

            /*int idPosition = reader.GetOrdinal("ID");
            int titlePosition = reader.GetOrdinal("Name");
            int imagePathPosition = reader.getOrdinal("ImagePath");
            int pricePosition = reader.*/

            int IDPosition = reader.GetOrdinal("ID");
            int DestinationPosition = reader.GetOrdinal("DestinationName");
            int AttractionsPosition = reader.GetOrdinal("Attractions");
            int BestTimeToGoPosition = reader.GetOrdinal("BestTimeToGo");                   
            while (reader.Read())
            {
                //newdestination.Add();
                newdestination.ID = reader.GetInt32(IDPosition);
                newdestination.Attractions = reader.GetString(AttractionsPosition);
                newdestination.BestTimeToGo = reader.GetString(BestTimeToGoPosition);
            }//Will read data line to line

            SqlCommand newCategoryCommand = connection.CreateCommand();

            List<VacationSuggestions> PlacesToGo = new List<VacationSuggestions>();            

            if(string.IsNullOrEmpty(BackToTravelResults))//This is if the user clicks the "undecided" button. It will take him to a page with a list of ideas (and a form).
            {
                Console.WriteLine("return current popular destinations");

                PlacesToGo.Add(new VacationSuggestions
                {
                    ID = 1, //added this
                    DestinationName = "Las Vegas",
                    Attractions = "Cirque Du Soleil, Comedy shows, BUFFETS!!!",
                    BestTimeToGo = "Winter"                    
                });

                PlacesToGo.Add(new VacationSuggestions
                {
                    ID = 2,
                    DestinationName = "Reno",
                    Attractions = "Lake Tahoe, Virginia City, Skiing",
                    BestTimeToGo = "Fall"                  
                });

                PlacesToGo.Add(new VacationSuggestions
                { 
                    ID = 3,
                    DestinationName = "Costa Rica",
                    Attractions = "Cloud Forest, Nightlife, Beaches",
                    BestTimeToGo = "Mid December to April"
                });

                PlacesToGo.Add(new VacationSuggestions
                { 
                    ID = 4,
                    DestinationName = "Hong Kong",
                    Attractions = "Shopping, Symphony of light dinner cruise, Hong Kong Disneyland",
                    BestTimeToGo = "October to December",                    
                });

                PlacesToGo.Add(new VacationSuggestions
                {
                    ID = 5,
                    image = "~/ images /SouthBeach.jpg",
                    DestinationName = "South Beach",
                    Attractions = "FOOD!!!, Beach, Walk down Ocean Drive",
                    BestTimeToGo = "Fall"

                });
         
            } 

            else if(BackToTravelResults.ToLowerInvariant() == "Las Vegas")
            {
                //Notice below the data is "Hard coded" (Las Vegas, Comedy shows, etc...). What if I ran a SELECT... FROM. I need to open a connection, run a query and convert it.

                PlacesToGo.Add(new VacationSuggestions
                {
                    ID = 1, //I just added this.
                    DestinationName = "Las Vegas",
                    Attractions = "Cirque Du Soleil, Comedy shows, BUFFETS!!!",
                    BestTimeToGo = "Winter"
                });                
            }            
            
            return View(PlacesToGo);
       }

        List<VacationerModel> Vacationer = new List<VacationerModel>();
        
        [HttpPost]
        public IActionResult NewTravelRequest(string CustomerFirstName, string CustomerLastName, string Email, string destination, double maxbudget, string additionalInfo)
        {
            //ViewData["customer"] = customername;
            Vacationer.Add(new VacationerModel { FirstName = CustomerFirstName, LastName = CustomerLastName, email = Email, DreamDestination = destination, budget = maxbudget, DestinationDescription = additionalInfo });            

            return View(Vacationer);
        }

        List<TravelAgentParameters> NewTravelAgent = new List<TravelAgentParameters>();

        //Below is the method that will process the form the new agent has entered.

        [HttpPost]
        public IActionResult NewAgentAccount(string AgentName, string AgentEmail, int AgentExperience, string asta, string AgentSpecialties, string AgentVisited)
        {
            NewTravelAgent.Add(new TravelAgentParameters { name = AgentName, email = AgentEmail, ASTACertified = asta, yearsexperience = AgentExperience, Specialties = AgentSpecialties, PlacesVisited = AgentVisited });

            return View(NewTravelAgent);
        } 
        
    }
}