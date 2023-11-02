using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventosTest.Data;
using EventosTestMVC.Models;

namespace EventosTestMVC.Controllers
{
    public class PlannersController : Controller
    {
        private readonly DataContext _context;

        public PlannersController(DataContext context)
        {
            _context = context;
        }

        // GET: Planners
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Planners.Include(p => p.AvatarPlanner);
            return View(await dataContext.ToListAsync());
        }

        // GET: Planners/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Planners == null)
            {
                return NotFound();
            }

            var planner = await _context.Planners
                .Include(p => p.AvatarPlanner)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // GET: Planners/Create
        public IActionResult Create()
        {
            ViewData["AvatarPlannerId"] = new SelectList(_context.AvatarPlanners, "Id", "Id");
            return View();
        }

        // POST: Planners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Planner planner)
        {

                _context.Add(planner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

        }

        // GET: Planners/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Planners == null)
            {
                return NotFound();
            }

            var planner = await _context.Planners.FindAsync(id);
            if (planner == null)
            {
                return NotFound();
            }
            ViewData["AvatarPlannerId"] = new SelectList(_context.AvatarPlanners, "Id", "Id", planner.AvatarPlannerId);
            return View(planner);
        }

        // POST: Planners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Password,Name,LastName,AvatarPlannerId")] Planner planner)
        {
            if (id != planner.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlannerExists(planner.Email))
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
            ViewData["AvatarPlannerId"] = new SelectList(_context.AvatarPlanners, "Id", "Id", planner.AvatarPlannerId);
            return View(planner);
        }

        // GET: Planners/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Planners == null)
            {
                return NotFound();
            }

            var planner = await _context.Planners
                .Include(p => p.AvatarPlanner)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // POST: Planners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Planners == null)
            {
                return Problem("Entity set 'DataContext.Planners'  is null.");
            }
            var planner = await _context.Planners.FindAsync(id);
            if (planner != null)
            {
                _context.Planners.Remove(planner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlannerExists(string id)
        {
          return (_context.Planners?.Any(e => e.Email == id)).GetValueOrDefault();
        }
    }
}
