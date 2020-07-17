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
    public class SaleitemsController : Controller
    {
        private readonly MatureFashionsContext _context;

        public SaleitemsController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Saleitems
        public async Task<IActionResult> Index()
        {
            var matureFashionsContext = _context.Saleitem.Include(s => s.ItemNoNavigation).Include(s => s.Shows);
            return View(await matureFashionsContext.ToListAsync());
        }

        // GET: Saleitems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleitem = await _context.Saleitem
                .Include(s => s.ItemNoNavigation)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (saleitem == null)
            {
                return NotFound();
            }

            return View(saleitem);
        }

        // GET: Saleitems/Create
        public IActionResult Create()
        {
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo");
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo");
            return View();
        }

        // POST: Saleitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseNo,HomeNo,ShowDate,ItemNo,SaleQuantity")] Saleitem saleitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo", saleitem.ItemNo);
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo", saleitem.FranchiseNo);
            return View(saleitem);
        }

        // GET: Saleitems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleitem = await _context.Saleitem.FindAsync(id);
            if (saleitem == null)
            {
                return NotFound();
            }
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo", saleitem.ItemNo);
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo", saleitem.FranchiseNo);
            return View(saleitem);
        }

        // POST: Saleitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchiseNo,HomeNo,ShowDate,ItemNo,SaleQuantity")] Saleitem saleitem)
        {
            if (id != saleitem.FranchiseNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleitemExists(saleitem.FranchiseNo))
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
            ViewData["ItemNo"] = new SelectList(_context.Item, "ItemNo", "ItemNo", saleitem.ItemNo);
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo", saleitem.FranchiseNo);
            return View(saleitem);
        }

        // GET: Saleitems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleitem = await _context.Saleitem
                .Include(s => s.ItemNoNavigation)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (saleitem == null)
            {
                return NotFound();
            }

            return View(saleitem);
        }

        // POST: Saleitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var saleitem = await _context.Saleitem.FindAsync(id);
            _context.Saleitem.Remove(saleitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleitemExists(string id)
        {
            return _context.Saleitem.Any(e => e.FranchiseNo == id);
        }
    }
}
