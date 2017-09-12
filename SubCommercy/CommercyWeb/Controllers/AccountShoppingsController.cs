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
    public class AccountShoppingsController : Controller
    {
        private readonly CommercyContext _context;

        public AccountShoppingsController(CommercyContext context)
        {
            _context = context;
        }

        // GET: AccountShoppings
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountShopping.ToListAsync());
        }

        // GET: AccountShoppings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountShopping = await _context.AccountShopping
                .SingleOrDefaultAsync(m => m.AccountShoppingId == id);
            if (accountShopping == null)
            {
                return NotFound();
            }

            return View(accountShopping);
        }

        // GET: AccountShoppings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountShoppings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountShoppingId,CustomerIdAccountShopping,ActiveAccountShopping,DtaAccountShopping")] AccountShopping accountShopping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountShopping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountShopping);
        }

        // GET: AccountShoppings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountShopping = await _context.AccountShopping.SingleOrDefaultAsync(m => m.AccountShoppingId == id);
            if (accountShopping == null)
            {
                return NotFound();
            }
            return View(accountShopping);
        }

        // POST: AccountShoppings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountShoppingId,CustomerIdAccountShopping,ActiveAccountShopping,DtaAccountShopping")] AccountShopping accountShopping)
        {
            if (id != accountShopping.AccountShoppingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountShopping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountShoppingExists(accountShopping.AccountShoppingId))
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
            return View(accountShopping);
        }

        // GET: AccountShoppings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountShopping = await _context.AccountShopping
                .SingleOrDefaultAsync(m => m.AccountShoppingId == id);
            if (accountShopping == null)
            {
                return NotFound();
            }

            return View(accountShopping);
        }

        // POST: AccountShoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountShopping = await _context.AccountShopping.SingleOrDefaultAsync(m => m.AccountShoppingId == id);
            _context.AccountShopping.Remove(accountShopping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountShoppingExists(int id)
        {
            return _context.AccountShopping.Any(e => e.AccountShoppingId == id);
        }
    }
}
