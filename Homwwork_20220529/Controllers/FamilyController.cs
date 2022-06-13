using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homework_EntityFramework.Models;

namespace Homework_EntityFramework.Controllers
{
    public class FamilyController : Controller
    {
        private readonly HomeworkDBContext _context;

        public FamilyController(HomeworkDBContext context)
        {
            _context = context;
        }

        // GET: Family
        public async Task<IActionResult> Index()
        {
              return _context.TblFamilies != null ? 
                          View(await _context.TblFamilies.ToListAsync()) :
                          Problem("Entity set 'HomeworkDBContext.TblFamilies'  is null.");
        }

        // GET: Family/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblFamilies == null)
            {
                return NotFound();
            }

            var tblFamily = await _context.TblFamilies
                .FirstOrDefaultAsync(m => m.FamilyId == id);
            if (tblFamily == null)
            {
                return NotFound();
            }

            return View(tblFamily);
        }

        // GET: Family/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Family/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FamilyId,Name,Age,Title,NickName")] TblFamily tblFamily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFamily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFamily);
        }

        // GET: Family/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblFamilies == null)
            {
                return NotFound();
            }

            var tblFamily = await _context.TblFamilies.FindAsync(id);
            if (tblFamily == null)
            {
                return NotFound();
            }
            return View(tblFamily);
        }

        // POST: Family/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FamilyId,Name,Age,Title,NickName")] TblFamily tblFamily)
        {
            if (id != tblFamily.FamilyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFamily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFamilyExists(tblFamily.FamilyId))
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
            return View(tblFamily);
        }

        // GET: Family/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblFamilies == null)
            {
                return NotFound();
            }

            var tblFamily = await _context.TblFamilies
                .FirstOrDefaultAsync(m => m.FamilyId == id);
            if (tblFamily == null)
            {
                return NotFound();
            }

            return View(tblFamily);
        }

        // POST: Family/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblFamilies == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblFamilies'  is null.");
            }
            var tblFamily = await _context.TblFamilies.FindAsync(id);
            if (tblFamily != null)
            {
                _context.TblFamilies.Remove(tblFamily);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFamilyExists(int id)
        {
          return (_context.TblFamilies?.Any(e => e.FamilyId == id)).GetValueOrDefault();
        }
    }
}
