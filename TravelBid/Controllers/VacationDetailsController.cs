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
    public class VacationDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacationDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VacationDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.newvacationrequest.ToListAsync());
        }

        // GET: VacationDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationDetails = await _context.newvacationrequest
                .SingleOrDefaultAsync(m => m.id == id);
            if (vacationDetails == null)
            {
                return NotFound();
            }

            return View(vacationDetails);
        }

        // GET: VacationDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VacationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DreamDestination,DestinationDescription,budget")] VacationDetails vacationDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacationDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacationDetails);
        }

        // GET: VacationDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationDetails = await _context.newvacationrequest.SingleOrDefaultAsync(m => m.id == id);
            if (vacationDetails == null)
            {
                return NotFound();
            }
            return View(vacationDetails);
        }

        // POST: VacationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DreamDestination,DestinationDescription,budget")] VacationDetails vacationDetails)
        {
            if (id != vacationDetails.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationDetailsExists(vacationDetails.id))
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
            return View(vacationDetails);
        }

        // GET: VacationDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationDetails = await _context.newvacationrequest
                .SingleOrDefaultAsync(m => m.id == id);
            if (vacationDetails == null)
            {
                return NotFound();
            }

            return View(vacationDetails);
        }

        // POST: VacationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacationDetails = await _context.newvacationrequest.SingleOrDefaultAsync(m => m.id == id);
            _context.newvacationrequest.Remove(vacationDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationDetailsExists(int id)
        {
            return _context.newvacationrequest.Any(e => e.id == id);
        }
    }
}
