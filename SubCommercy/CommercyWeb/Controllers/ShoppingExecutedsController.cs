using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommercyDomain.Entities;
using CommercyWeb.Models;
using Commercy.Infra.Data.Context;

namespace CommercyWeb.Controllers
{
    public class ShoppingExecutedsController : Controller
    {
        private readonly CommercyContext _context;

        public ShoppingExecutedsController(CommercyContext context)
        {
            _context = context;
        }

        // GET: ShoppingExecuteds
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoppingExecuted.ToListAsync());
        }

        // GET: ShoppingExecuteds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingExecuted = await _context.ShoppingExecuted
                .SingleOrDefaultAsync(m => m.ShoppingExecutedId == id);
            if (shoppingExecuted == null)
            {
                return NotFound();
            }

            return View(shoppingExecuted);
        }

        // GET: ShoppingExecuteds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingExecuteds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingExecutedId,TotalShopping,DtaShopping,StatusShopping")] ShoppingExecuted shoppingExecuted)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingExecuted);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingExecuted);
        }

        // GET: ShoppingExecuteds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingExecuted = await _context.ShoppingExecuted.SingleOrDefaultAsync(m => m.ShoppingExecutedId == id);
            if (shoppingExecuted == null)
            {
                return NotFound();
            }
            return View(shoppingExecuted);
        }

        // POST: ShoppingExecuteds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingExecutedId,TotalShopping,DtaShopping,StatusShopping")] ShoppingExecuted shoppingExecuted)
        {
            if (id != shoppingExecuted.ShoppingExecutedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingExecuted);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingExecutedExists(shoppingExecuted.ShoppingExecutedId))
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
            return View(shoppingExecuted);
        }

        // GET: ShoppingExecuteds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingExecuted = await _context.ShoppingExecuted
                .SingleOrDefaultAsync(m => m.ShoppingExecutedId == id);
            if (shoppingExecuted == null)
            {
                return NotFound();
            }

            return View(shoppingExecuted);
        }

        // POST: ShoppingExecuteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingExecuted = await _context.ShoppingExecuted.SingleOrDefaultAsync(m => m.ShoppingExecutedId == id);
            _context.ShoppingExecuted.Remove(shoppingExecuted);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingExecutedExists(int id)
        {
            return _context.ShoppingExecuted.Any(e => e.ShoppingExecutedId == id);
        }
    }
}
