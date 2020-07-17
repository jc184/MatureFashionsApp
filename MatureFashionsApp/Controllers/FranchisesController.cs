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
    public class FranchisesController : Controller
    {
        private readonly MatureFashionsContext _context;

        public FranchisesController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Franchises
        public async Task<IActionResult> Index()
        {
            var matureFashionsContext = _context.Franchise.Include(f => f.FranchisorNoNavigation);
            return View(await matureFashionsContext.ToListAsync());
        }

        // GET: Franchises/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
                .Include(f => f.FranchisorNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // GET: Franchises/Create
        public IActionResult Create()
        {
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisor, "FranchisorNo", "FranchisorNo");
            return View();
        }

        // POST: Franchises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseNo,FranchiseName,FranchiseAddress,FranchisePostcode,FranchiseTel,FranchiseFax,FranchiseStartdate,FranchisorNo")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisor, "FranchisorNo", "FranchisorNo", franchise.FranchisorNo);
            return View(franchise);
        }

        // GET: Franchises/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisor, "FranchisorNo", "FranchisorNo", franchise.FranchisorNo);
            return View(franchise);
        }

        // POST: Franchises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchiseNo,FranchiseName,FranchiseAddress,FranchisePostcode,FranchiseTel,FranchiseFax,FranchiseStartdate,FranchisorNo")] Franchise franchise)
        {
            if (id != franchise.FranchiseNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchiseExists(franchise.FranchiseNo))
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
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisor, "FranchisorNo", "FranchisorNo", franchise.FranchisorNo);
            return View(franchise);
        }

        // GET: Franchises/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
                .Include(f => f.FranchisorNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // POST: Franchises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var franchise = await _context.Franchise.FindAsync(id);
            _context.Franchise.Remove(franchise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchiseExists(string id)
        {
            return _context.Franchise.Any(e => e.FranchiseNo == id);
        }
    }
}
