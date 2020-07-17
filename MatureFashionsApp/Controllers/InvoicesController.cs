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
    public class InvoicesController : Controller
    {
        private readonly MatureFashionsContext _context;

        public InvoicesController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var matureFashionsContext = _context.Invoice.Include(i => i.FranchiseNoNavigation).Include(i => i.OrderNoNavigation);
            return View(await matureFashionsContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.FranchiseNoNavigation)
                .Include(i => i.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.InvoiceNo == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo");
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceNo,InvoiceDate,InvoiceDateDue,InvoiceNet,FranchiseNo,OrderNo")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", invoice.FranchiseNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", invoice.OrderNo);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", invoice.FranchiseNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", invoice.OrderNo);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("InvoiceNo,InvoiceDate,InvoiceDateDue,InvoiceNet,FranchiseNo,OrderNo")] Invoice invoice)
        {
            if (id != invoice.InvoiceNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceNo))
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
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", invoice.FranchiseNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", invoice.OrderNo);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.FranchiseNoNavigation)
                .Include(i => i.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.InvoiceNo == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(string id)
        {
            return _context.Invoice.Any(e => e.InvoiceNo == id);
        }
    }
}
