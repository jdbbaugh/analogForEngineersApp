using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using analogCapstone.Data;
using analogCapstone.Models;

namespace analogCapstone.Controllers
{
    public class KnobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KnobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Knobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Knob.Include(k => k.Gear);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Knobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knob = await _context.Knob
                .Include(k => k.Gear)
                .FirstOrDefaultAsync(m => m.KnobId == id);
            if (knob == null)
            {
                return NotFound();
            }

            return View(knob);
        }

        // GET: Knobs/Create
        public IActionResult Create()
        {
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "Make");
            return View();
        }

        // POST: Knobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KnobId,KnobName,GearId,Ordinal")] Knob knob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "Make", knob.GearId);
            return View(knob);
        }

        // GET: Knobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knob = await _context.Knob.FindAsync(id);
            if (knob == null)
            {
                return NotFound();
            }
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "Make", knob.GearId);
            return View(knob);
        }

        // POST: Knobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KnobId,KnobName,GearId,Ordinal")] Knob knob)
        {
            if (id != knob.KnobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnobExists(knob.KnobId))
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
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "Make", knob.GearId);
            return View(knob);
        }

        // GET: Knobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knob = await _context.Knob
                .Include(k => k.Gear)
                .FirstOrDefaultAsync(m => m.KnobId == id);
            if (knob == null)
            {
                return NotFound();
            }

            return View(knob);
        }

        // POST: Knobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knob = await _context.Knob.FindAsync(id);
            _context.Knob.Remove(knob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnobExists(int id)
        {
            return _context.Knob.Any(e => e.KnobId == id);
        }
    }
}
