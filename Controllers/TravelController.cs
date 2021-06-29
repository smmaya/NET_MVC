using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSMan.Data;
using PSMan.Models;

namespace PSMan.Controllers
{
    public class TravelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Travel
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelModel.ToListAsync());
        }

        // GET: Travel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelModel = await _context.TravelModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelModel == null)
            {
                return NotFound();
            }

            return View(travelModel);
        }

        // GET: Travel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Travel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Flight,FromCity,FromDepartureTime,ToCity,ToLandingTime")] TravelModel travelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelModel);
        }

        // GET: Travel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelModel = await _context.TravelModel.FindAsync(id);
            if (travelModel == null)
            {
                return NotFound();
            }
            return View(travelModel);
        }

        // POST: Travel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Flight,FromCity,FromDepartureTime,ToCity,ToLandingTime")] TravelModel travelModel)
        {
            if (id != travelModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelModelExists(travelModel.Id))
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
            return View(travelModel);
        }

        // GET: Travel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelModel = await _context.TravelModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelModel == null)
            {
                return NotFound();
            }

            return View(travelModel);
        }

        // POST: Travel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelModel = await _context.TravelModel.FindAsync(id);
            _context.TravelModel.Remove(travelModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelModelExists(int id)
        {
            return _context.TravelModel.Any(e => e.Id == id);
        }
    }
}
