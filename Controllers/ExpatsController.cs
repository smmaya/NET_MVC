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
    public class ExpatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expats
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Expats.ToListAsync());
        //}

        public async Task<IActionResult> Index(string searchString)
        {
            var expats = from m in _context.Expats
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                expats = expats.Where(s => s.LName.Contains(searchString));
            }

            return View(await expats.ToListAsync());
        }

        // GET: Expats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expatsModel = await _context.Expats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expatsModel == null)
            {
                return NotFound();
            }

            return View(expatsModel);
        }

        // GET: Expats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FName,LName,Company,Email")] ExpatsModel expatsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expatsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expatsModel);
        }

        // GET: Expats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expatsModel = await _context.Expats.FindAsync(id);
            if (expatsModel == null)
            {
                return NotFound();
            }
            return View(expatsModel);
        }

        // POST: Expats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FName,LName,Company,Email")] ExpatsModel expatsModel)
        {
            if (id != expatsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expatsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpatsModelExists(expatsModel.Id))
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
            return View(expatsModel);
        }

        // GET: Expats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expatsModel = await _context.Expats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expatsModel == null)
            {
                return NotFound();
            }

            return View(expatsModel);
        }

        // POST: Expats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expatsModel = await _context.Expats.FindAsync(id);
            _context.Expats.Remove(expatsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpatsModelExists(int id)
        {
            return _context.Expats.Any(e => e.Id == id);
        }
    }
}
