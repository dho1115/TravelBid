using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBid.Models;

namespace TravelBid.Controllers
{
    public class VacationERController : Controller
    {
        public IActionResult Index()
        {

           return View();
        }

        public IActionResult NewVacationerRegistration()
        {
            return View();
        } 

        public IActionResult LoginHome(string loginname = "vacationer")
        {     
            if (loginname == "vacationer")
            {
                return View();
            }

            else
            {
                return Content("Wrong!!!");

                //return RedirectToAction("index", "Home");
            }                            
        }

        List<VacationerModel> VacationerProfile = new List<VacationerModel>();

        public IActionResult Confirmation(string CustomerFirstName, string CustomerLastName, string Email, string destination, double maxbudget, string additionalInfo)
        {
            VacationerProfile.Add(new VacationerModel {
                FirstName = CustomerFirstName,
                LastName = CustomerLastName,
                email = Email,
                DreamDestination = destination,
                DestinationDescription = additionalInfo,
                budget = maxbudget
            });

            return View(VacationerProfile);
        }

        List<VacationerModel> ProfileForSubmission = new List<VacationerModel>();

        public IActionResult Personal_Information(string CustomerFirstName, string CustomerLastName, string Email, string destination, double maxbudget, string additionalInfo)
        {
            ProfileForSubmission.Add(new VacationerModel
            {
                FirstName = CustomerFirstName,
                LastName = CustomerLastName,
                email = Email,
                DreamDestination = destination,
                DestinationDescription = additionalInfo,
                budget = maxbudget
            });

            //This will APPEND the information to an existing filePath.
            string fName = "\n\n\n" + CustomerFirstName + "\n";            
            string lName = CustomerLastName + "\n";
            string emailaddress = Email;
            string vacationspot = "\n" + destination + "\n";
            double Budget = maxbudget;
            string AddDetails = "\n" + additionalInfo;
            

            string filePath = "C:\\Users\\Owner\\Desktop\\TravelBidVacations.doc";

            System.IO.File.AppendAllText(filePath, fName);
            System.IO.File.AppendAllText(filePath, lName);
            System.IO.File.AppendAllText(filePath, Email);
            System.IO.File.AppendAllText(filePath, vacationspot);
            System.IO.File.AppendAllText(filePath, maxbudget.ToString());
            System.IO.File.AppendAllText(filePath, AddDetails);
            
            return View(ProfileForSubmission);
        }

        //********//

        PersonalInfoVacationer newVacationer = new PersonalInfoVacationer(1, "Jamie", "Smythe", "JamieSmythe@email.com");

        VacationDetails JamiesVacation = new VacationDetails(1, "Reno,NV", "I want to go to Reno!!!", 2900);

        List<CombinedInfoVacationer> newInfo1 = new List<CombinedInfoVacationer>();

        public IActionResult vacationrequest()
        {
            newInfo1.Add(new CombinedInfoVacationer { Traveler = newVacationer, vacationdetails = JamiesVacation});

            return View(newInfo1);

        }
    }
}