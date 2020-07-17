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
    public class PartnersController : Controller
    {
        private readonly MatureFashionsContext _context;

        public PartnersController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Partners
        public async Task<IActionResult> Index()
        {
            var matureFashionsContext = _context.Partner.Include(p => p.FranchiseNoNavigation);
            return View(await matureFashionsContext.ToListAsync());
        }

        // GET: Partners/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partner
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo");
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseNo,PartnerName")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", partner.FranchiseNo);
            return View(partner);
        }

        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partner.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", partner.FranchiseNo);
            return View(partner);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchiseNo,PartnerName")] Partner partner)
        {
            if (id != partner.FranchiseNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.FranchiseNo))
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
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", partner.FranchiseNo);
            return View(partner);
        }

        // GET: Partners/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partner
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var partner = await _context.Partner.FindAsync(id);
            _context.Partner.Remove(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(string id)
        {
            return _context.Partner.Any(e => e.FranchiseNo == id);
        }
    }
}
