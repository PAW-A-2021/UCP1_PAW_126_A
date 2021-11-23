using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_126_A.Models;

namespace UCP1_PAW_126_A.Controllers
{
    public class AdmiinsController : Controller
    {
        private readonly UCP1_PAW_AContext _context;

        public AdmiinsController(UCP1_PAW_AContext context)
        {
            _context = context;
        }

        // GET: Admiins
        public async Task<IActionResult> Index()
        {
            var uCP1_PAW_AContext = _context.Admiins.Include(a => a.IdUserNavigation);
            return View(await uCP1_PAW_AContext.ToListAsync());
        }

        // GET: Admiins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admiin = await _context.Admiins
                .Include(a => a.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (admiin == null)
            {
                return NotFound();
            }

            return View(admiin);
        }

        // GET: Admiins/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser");
            return View();
        }

        // POST: Admiins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdmin,IdUser,Password")] Admiin admiin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admiin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", admiin.IdUser);
            return View(admiin);
        }

        // GET: Admiins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admiin = await _context.Admiins.FindAsync(id);
            if (admiin == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", admiin.IdUser);
            return View(admiin);
        }

        // POST: Admiins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdmin,IdUser,Password")] Admiin admiin)
        {
            if (id != admiin.IdAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admiin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmiinExists(admiin.IdAdmin))
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
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", admiin.IdUser);
            return View(admiin);
        }

        // GET: Admiins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admiin = await _context.Admiins
                .Include(a => a.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (admiin == null)
            {
                return NotFound();
            }

            return View(admiin);
        }

        // POST: Admiins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admiin = await _context.Admiins.FindAsync(id);
            _context.Admiins.Remove(admiin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmiinExists(int id)
        {
            return _context.Admiins.Any(e => e.IdAdmin == id);
        }
    }
}
