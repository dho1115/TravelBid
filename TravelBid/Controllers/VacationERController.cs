using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBid.Models;
using System.Data.SqlClient;
using TravelBid.Data;

namespace TravelBid.Controllers
{
    public class VacationERController : Controller
    {
        private ApplicationDbContext _context;

        public VacationERController(ApplicationDbContext context)
        {
            this._context = context; //This injects the context so you can use it across the methods.
        } 

        public IActionResult Index(string vacation)
        {
            if(_context.newvacationrequest.Count()==0)
            {
                List<VacationDetails> newrequest = new List<VacationDetails>();

                newrequest.Add(new VacationDetails { DreamDestination = "Austin,Tx", DestinationDescription = "Looking for an agent to help me go to TX", budget = 2700}); 

                _context.newvacationrequest.AddRange(newrequest);
               
                _context.SaveChanges();
            }  

            if(_context.NewVacationerModel.Count()==0)
            {
                List<VacationerModel> VacationerModelForm = new List<VacationerModel>();

                VacationerModelForm.Add(new VacationerModel
                {
                    ID = 1,
                    FirstName = "Andie",
                    LastName = "Richards",
                    email = "ARichards@someemail.com",
                    DreamDestination = "Boston,MA",
                    budget = 2900.00,
                    DestinationDescription = "I am looking for and agent to help plan my Boston vacation."
                });

                _context.NewVacationerModel.AddRange(VacationerModelForm);

                _context.SaveChanges();
            }            

            ViewBag.selectedVacation = vacation;

            List<VacationerModel> model;

            if(string.IsNullOrEmpty(vacation))
            {
                model = this._context.NewVacationerModel.ToList(); // <=This replaces the select * from.... If the user does not select anything, this will return everything.
            } 

            else
            {
                model = this._context.NewVacationerModel.Where(x => x.VacationerModelFK == vacation).ToList(); //This is if the user chooses a place to go (perhaps from a drop-down list?). Side note: This works only for a DROP-DOWN list. If I do not have a drop-down list, I would have to do somehting different. 
            }

            return View(model);
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
                //return Content("Wrong!!!");

                return RedirectToAction("Index", "Home");
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

            //NOTE: The code with the cookies does two things: it adds the cookie to the cart and at the same time, it adds the products to the cart after the user selects the ite from the dropdown list 

            return View(VacationerProfile);
        }

        List<VacationerModel> ProfileForSubmission = new List<VacationerModel>();

        public IActionResult Personal_Information(string CustomerFirstName, string CustomerLastName, string Email, string destination, double maxbudget, string additionalInfo)
        {
            /*
            ProfileForSubmission.Add(new VacationerModel
            {
                FirstName = CustomerFirstName,
                LastName = CustomerLastName,
                email = Email,
                DreamDestination = destination,
                DestinationDescription = additionalInfo,
                budget = maxbudget
            });
            */
            ProfileForSubmission.Add(new VacationerModel
            {
                FirstName = "Jamie",
                LastName = "Smythe",
                email = "jse@email.com",
                DreamDestination = "Texas",
                DestinationDescription = "Looking to go to Texas.",
                budget = 2900.00
            }); 

            /*
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
            */

            return View(ProfileForSubmission);           
        }



        /*
        PersonalInfoVacationer newVacationer = new PersonalInfoVacationer(1, "Jamie", "Smythe", "JamieSmythe@email.com");

        VacationDetails JamiesVacation = new VacationDetails(1, "Reno,NV", "I want to go to Reno!!!", 2900);

        List<CombinedInfoVacationer> newInfo1 = new List<CombinedInfoVacationer>();

        public IActionResult vacationrequest()
        {
            newInfo1.Add(new CombinedInfoVacationer { Traveler = newVacationer, vacationdetails = JamiesVacation});

            return View(newInfo1);

        } 
        */

        /* This will add the entire cart in, but will not update the cart. It basically "dumps" the cart and returns a new cart.*/


      
    }
}