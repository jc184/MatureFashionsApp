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
    public class PostcodesController : Controller
    {
        private readonly MatureFashionsContext _context;

        public PostcodesController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Postcodes
        public async Task<IActionResult> Index()
        {
            var matureFashionsContext = _context.Postcode.Include(p => p.FranchiseNoNavigation);
            return View(await matureFashionsContext.ToListAsync());
        }

        // GET: Postcodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcode = await _context.Postcode
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.PostcodeArea == id);
            if (postcode == null)
            {
                return NotFound();
            }

            return View(postcode);
        }

        // GET: Postcodes/Create
        public IActionResult Create()
        {
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo");
            return View();
        }

        // POST: Postcodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostcodeArea,PostcodeName,FranchiseNo")] Postcode postcode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postcode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", postcode.FranchiseNo);
            return View(postcode);
        }

        // GET: Postcodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcode = await _context.Postcode.FindAsync(id);
            if (postcode == null)
            {
                return NotFound();
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", postcode.FranchiseNo);
            return View(postcode);
        }

        // POST: Postcodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PostcodeArea,PostcodeName,FranchiseNo")] Postcode postcode)
        {
            if (id != postcode.PostcodeArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postcode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostcodeExists(postcode.PostcodeArea))
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
            ViewData["FranchiseNo"] = new SelectList(_context.Franchise, "FranchiseNo", "FranchiseNo", postcode.FranchiseNo);
            return View(postcode);
        }

        // GET: Postcodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcode = await _context.Postcode
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.PostcodeArea == id);
            if (postcode == null)
            {
                return NotFound();
            }

            return View(postcode);
        }

        // POST: Postcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var postcode = await _context.Postcode.FindAsync(id);
            _context.Postcode.Remove(postcode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostcodeExists(string id)
        {
            return _context.Postcode.Any(e => e.PostcodeArea == id);
        }
    }
}
