using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBid.Models;
using System.IO;

namespace TravelBid.Controllers
{
    public class TravelAgentsController : Controller
    {
        public IActionResult LoginHome()
        {
            return View();
        }

        List<TravelAgentParameters> ProfessionalInfo = new List<TravelAgentParameters>();

        
        public IActionResult ProfessionalInformation()
        {
          return View(ProfessionalInfo);
        }

        [HttpPost]
        public IActionResult ProfessionalInformation(string AgentName, string AgentEmail, int AgentExperience, string asta, string AgentSpecialties, string AgentVisited)
        {
            ProfessionalInfo.Add(new TravelAgentParameters { name = AgentName, email = AgentEmail, yearsexperience = AgentExperience, ASTACertified = asta, Specialties = AgentSpecialties, PlacesVisited = AgentVisited });

            return View(ProfessionalInfo);
        } 

        public IActionResult VacationRequestQueue()
        {            
            string sourceFilePath = @"C:\Users\Owner\Desktop\TravelBidVacations.doc";

            string data;

            // Create a FileStream object so that you can interact with the file
            // system.

                FileStream sourceFile = new System.IO.FileStream(   
                sourceFilePath,  // Pass in the source file path.
                FileMode.Open,   // Open an existing file.
                FileAccess.Read);// Read an existing file.

            StreamReader reader = new StreamReader(sourceFile);

            // Read the entire file into a single string variable.

            data = reader.ReadToEnd();

            // Always close the underlying streams release any file handles.

            reader.Close();
            sourceFile.Close();

            ViewBag.result = data;

            return View();
        }
        
    }
}