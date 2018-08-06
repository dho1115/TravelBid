using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBid.Models;

namespace TravelBid.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {   
            /*
            string filePath = "C:\\Users\\Owner\\Desktop\\TravelBidVacations.doc";
            string filecontents = "VACATION REQUESTS..." + "\n\n\n";

            System.IO.File.WriteAllText(filePath, filecontents);
            */

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        } 

        public IActionResult NewAgentAccount()
        {
            return View();
        } 

        public IActionResult NewAgentQuestionairre()
        {
            return View();
        }

        public IActionResult NewVacationerProfile()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        } 

        public IActionResult AgentLoginPage()
        {
            return View();
        }

        /*
        public IActionResult LoginProcessing(string loginname)
        {            
            if(loginname == "vacationer")
            {
                return View();
            }
            
            else
            {
                return RedirectToAction("index","Home");
            }
            
        }
        */
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
