using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homework_EntityFramework.Models;
using Homework_EntityFramework.Models;

namespace Homework_EntityFramework.Controllers
{
    public class FoodController : Controller
    {
        private readonly HomeworkDBContext _context;

        public FoodController(HomeworkDBContext context)
        {
            _context = context;
        }

        // GET: Food
        public async Task<IActionResult> Index()
        {
            return _context.TblFoods != null ?
                        View(await _context.TblFoods.ToListAsync()) :
                        Problem("Entity set 'HomeworkDBContext.TblFoods'  is null.");
        }
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            await Task.Delay(1);
            FoodViewModel food = new FoodViewModel(_context);
            return View(food);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([Bind(Prefix = "_search")] Search search)
        {
            FoodViewModel food = new FoodViewModel(_context);
            food._search = search;
            await food.GetFoods();//_food變更
            return View(food);
        }

        // GET: Food/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblFoods == null)
            {
                return NotFound();
            }

            var tblFood = await _context.TblFoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFood == null)
            {
                return NotFound();
            }

            return View(tblFood);
        }

        // GET: Food/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Style,Stars,Price,Comment")] TblFood tblFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFood);
        }

        // GET: Food/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblFoods == null)
            {
                return NotFound();
            }

            var tblFood = await _context.TblFoods.FindAsync(id);
            if (tblFood == null)
            {
                return NotFound();
            }
            return View(tblFood);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Style,Stars,Price,Comment")] TblFood tblFood)
        {
            if (id != tblFood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFoodExists(tblFood.Id))
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
            return View(tblFood);
        }

        // GET: Food/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblFoods == null)
            {
                return NotFound();
            }

            var tblFood = await _context.TblFoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFood == null)
            {
                return NotFound();
            }

            return View(tblFood);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblFoods == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblFoods'  is null.");
            }
            var tblFood = await _context.TblFoods.FindAsync(id);
            if (tblFood != null)
            {
                _context.TblFoods.Remove(tblFood);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFoodExists(int id)
        {
            return (_context.TblFoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
