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
    public class AvatarPlannersController : Controller
    {
        private readonly DataContext _context;

        public AvatarPlannersController(DataContext context)
        {
            _context = context;
        }

        // GET: AvatarPlanners
        public async Task<IActionResult> Index()
        {
              return _context.AvatarPlanners != null ? 
                          View(await _context.AvatarPlanners.ToListAsync()) :
                          Problem("Entity set 'DataContext.AvatarPlanners'  is null.");
        }

        // GET: AvatarPlanners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvatarPlanners == null)
            {
                return NotFound();
            }

            var avatarPlanner = await _context.AvatarPlanners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avatarPlanner == null)
            {
                return NotFound();
            }

            return View(avatarPlanner);
        }

        // GET: AvatarPlanners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvatarPlanners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(AvatarPlanner avatarPlanner)
        {

                _context.Add(avatarPlanner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: AvatarPlanners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvatarPlanners == null)
            {
                return NotFound();
            }

            var avatarPlanner = await _context.AvatarPlanners.FindAsync(id);
            if (avatarPlanner == null)
            {
                return NotFound();
            }
            return View(avatarPlanner);
        }

        // POST: AvatarPlanners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl")] AvatarPlanner avatarPlanner)
        {
            if (id != avatarPlanner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avatarPlanner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvatarPlannerExists(avatarPlanner.Id))
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
            return View(avatarPlanner);
        }

        // GET: AvatarPlanners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvatarPlanners == null)
            {
                return NotFound();
            }

            var avatarPlanner = await _context.AvatarPlanners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avatarPlanner == null)
            {
                return NotFound();
            }

            return View(avatarPlanner);
        }

        // POST: AvatarPlanners/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvatarPlanners == null)
            {
                return Problem("Entity set 'DataContext.AvatarPlanners'  is null.");
            }
            var avatarPlanner = await _context.AvatarPlanners.Include(p => p.Planners).FirstOrDefaultAsync(ap => ap.Id == id);
            if (avatarPlanner != null)
            {
                _context.AvatarPlanners.Remove(avatarPlanner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvatarPlannerExists(int id)
        {
          return (_context.AvatarPlanners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
