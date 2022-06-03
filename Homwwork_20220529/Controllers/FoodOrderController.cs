﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homwwork_20220529.Models;

namespace Homwwork_20220529.Controllers
{
    public class FoodOrderController : Controller
    {
        private readonly HomeworkDBContext _context;

        public FoodOrderController(HomeworkDBContext context)
        {
            _context = context;
        }
        private async Task BindBiewBag()
        {
            ViewBag.FoodList = await _context.TblFoods.ToDictionaryAsync(x => x.Id, x => x.Name);
            ViewBag.CustomerList = await _context.TblCustomers.ToDictionaryAsync(x => x.Id, x => x.Name);
        }
        // GET: FoodOrder
        public async Task<IActionResult> Index()
        {
            return _context.TblFoodOrders != null ?
                        View(await _context.TblFoodOrders.ToListAsync()) :
                        Problem("Entity set 'HomeworkDBContext.TblFoodOrders'  is null.");
        }

        // GET: FoodOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblFoodOrders == null)
            {
                return NotFound();
            }

            var tblFoodOrder = await _context.TblFoodOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFoodOrder == null)
            {
                return NotFound();
            }

            return View(tblFoodOrder);
        }

        // GET: FoodOrder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,Fid,OrderDatetime,PaidDateTime")] TblFoodOrder tblFoodOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFoodOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFoodOrder);
        }

        // GET: FoodOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblFoodOrders == null)
            {
                return NotFound();
            }

            var tblFoodOrder = await _context.TblFoodOrders.FindAsync(id);
            if (tblFoodOrder == null)
            {
                return NotFound();
            }
            await BindBiewBag();
            return View(tblFoodOrder);
        }
        // POST: FoodOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,Fid,OrderDatetime,PaidDateTime")] TblFoodOrder tblFoodOrder)
        {
            var ErrorMessage = string.Empty;
            if (id != tblFoodOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (tblFoodOrder.CustomerId == -1)
                    {
                        ErrorMessage += "請選擇顧客";
                    }
                    else if (tblFoodOrder.Fid == -1)
                    {
                        ErrorMessage += "請選擇食物";
                    }
                    if (string.IsNullOrEmpty(ErrorMessage))
                    {
                        _context.Update(tblFoodOrder);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFoodOrderExists(tblFoodOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            TempData["ErrorMessage"] = ErrorMessage;
            await BindBiewBag();
            return View(tblFoodOrder);
        }
        public async Task<IActionResult> PayFoodOrder()
        {
            await Task.Delay(1);
            return View();
        }


        // GET: FoodOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblFoodOrders == null)
            {
                return NotFound();
            }

            var tblFoodOrder = await _context.TblFoodOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFoodOrder == null)
            {
                return NotFound();
            }

            return View(tblFoodOrder);
        }

        // POST: FoodOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblFoodOrders == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblFoodOrders'  is null.");
            }
            var tblFoodOrder = await _context.TblFoodOrders.FindAsync(id);
            if (tblFoodOrder != null)
            {
                _context.TblFoodOrders.Remove(tblFoodOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFoodOrderExists(int id)
        {
            return (_context.TblFoodOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
