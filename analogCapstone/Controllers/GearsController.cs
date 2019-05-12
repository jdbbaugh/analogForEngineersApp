using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using analogCapstone.Data;
using analogCapstone.Models;
using analogCapstone.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace analogCapstone.Controllers
{
    public class GearsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GearsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Gears
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var gearList = await _context.Gear
                .Include(g => g.ChannelToGears)
                .Include(g => g.Knobs)
                .OrderBy(g => g.Type)
                .ToListAsync();
            GearIndexViewModel allGear = new GearIndexViewModel();
            allGear.ApplicationUser = user;
            allGear.Gears = gearList;
            return View(allGear);
        }

        // GET: Gears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gear
                .Include(k => k.Knobs)
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // GET: Gears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GearId,Make,Model,Type,OrdinalsAvailable")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gear);
                await _context.SaveChangesAsync();
                for (int i = 0; i < gear.OrdinalsAvailable; i++)
                {
                    Knob newKnob = new Knob
                    {
                        KnobName = "Enter Name",
                        GearId = gear.GearId,
                        Ordinal = i + 1
                    };
                    _context.Add(newKnob);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gear);
        }

        public async Task<IActionResult> EditKnobNames(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AllKnobsEditViewModel allKnobs = new AllKnobsEditViewModel();
            var knobsToEdit = await _context.Knob
                .Where(k => k.GearId == id).ToListAsync();
            var gearEditing = await _context.Gear
                .FirstOrDefaultAsync(g => g.GearId == id);

            allKnobs.Gear = gearEditing;
            allKnobs.Knobs = knobsToEdit;
            return View(allKnobs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditKnobNames(AllKnobsEditViewModel allKnobs)
        {
            if (ModelState.IsValid)
            {
                using (var db = _context)
                {
                    foreach (var item in allKnobs.Knobs)
                    {
                        db.Knob.Update(item);
                        await _context.SaveChangesAsync();
                    }

                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(allKnobs);
        }

        // GET: Gears/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gear
                .FindAsync(id);
            if (gear == null)
            {
                return NotFound();
            }
            return View(gear);
        }

        // POST: Gears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GearId,Make,Model,Type,OrdinalsAvailable")] Gear gear)
        {
            if (id != gear.GearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearExists(gear.GearId))
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
            return View(gear);
        }

        // GET: Gears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gear
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // POST: Gears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gear = await _context.Gear.FindAsync(id);
            _context.Gear.Remove(gear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearExists(int id)
        {
            return _context.Gear.Any(e => e.GearId == id);
        }
    }
}
