using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatureFashionsApp.Models.DB;

namespace MatureFashionsApp.Controllers
{
    public class OrderlinesController : Controller
    {
        private readonly MatureFashionsContext _context;

        public OrderlinesController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Orderlines
        public async Task<IActionResult> Index()
        {
            var matureFashionsContext = _context.Orderline.Include(o => o.ItemNoNavigation).Include(o => o.OrderNoNavigation);
            return View(await matureFashionsContext.ToListAsync());
        }

        // GET: Orderlines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = await _context.Orderline
                .Include(o => o.ItemNoNavigation)
                .Include(o => o.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.OrderNo == id);
            if (orderline == null)
            {
                return NotFound();
            }

            return View(orderline);
        }

        // GET: Orderlines/Create
        public IActionResult Create()
        {
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo");
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo");
            return View();
        }

        // POST: Orderlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderNo,ItemNo,OrderQuantity")] Orderline orderline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo", orderline.ItemNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", orderline.OrderNo);
            return View(orderline);
        }

        // GET: Orderlines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = await _context.Orderline.FindAsync(id);
            if (orderline == null)
            {
                return NotFound();
            }
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo", orderline.ItemNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", orderline.OrderNo);
            return View(orderline);
        }

        // POST: Orderlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderNo,ItemNo,OrderQuantity")] Orderline orderline)
        {
            if (id != orderline.OrderNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderlineExists(orderline.OrderNo))
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
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo", orderline.ItemNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", orderline.OrderNo);
            return View(orderline);
        }

        // GET: Orderlines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = await _context.Orderline
                .Include(o => o.ItemNoNavigation)
                .Include(o => o.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.OrderNo == id);
            if (orderline == null)
            {
                return NotFound();
            }

            return View(orderline);
        }

        // POST: Orderlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orderline = await _context.Orderline.FindAsync(id);
            _context.Orderline.Remove(orderline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderlineExists(string id)
        {
            return _context.Orderline.Any(e => e.OrderNo == id);
        }
    }
}
