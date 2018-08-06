using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBid.Data;
using TravelBid.Models;

namespace TravelBid.Controllers
{
    public class TravelAgentParametersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelAgentParametersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelAgentParameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelAgentParameters.ToListAsync());
        }

        // GET: TravelAgentParameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentParameters = await _context.TravelAgentParameters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (travelAgentParameters == null)
            {
                return NotFound();
            }

            return View(travelAgentParameters);
        }

        // GET: TravelAgentParameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelAgentParameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,yearsexperience,ASTACertified,Specialties,PlacesVisited,email,DateCreated,DateLastModified")] TravelAgentParameters travelAgentParameters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelAgentParameters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelAgentParameters);
        }

        // GET: TravelAgentParameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentParameters = await _context.TravelAgentParameters.SingleOrDefaultAsync(m => m.ID == id);
            if (travelAgentParameters == null)
            {
                return NotFound();
            }
            return View(travelAgentParameters);
        }

        // POST: TravelAgentParameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,yearsexperience,ASTACertified,Specialties,PlacesVisited,email,DateCreated,DateLastModified")] TravelAgentParameters travelAgentParameters)
        {
            if (id != travelAgentParameters.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelAgentParameters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelAgentParametersExists(travelAgentParameters.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(travelAgentParameters);
        }

        // GET: TravelAgentParameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgentParameters = await _context.TravelAgentParameters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (travelAgentParameters == null)
            {
                return NotFound();
            }

            return View(travelAgentParameters);
        }

        // POST: TravelAgentParameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelAgentParameters = await _context.TravelAgentParameters.SingleOrDefaultAsync(m => m.ID == id);
            _context.TravelAgentParameters.Remove(travelAgentParameters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelAgentParametersExists(int id)
        {
            return _context.TravelAgentParameters.Any(e => e.ID == id);
        }
    }
}
