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
    public class FranchisorsController : Controller
    {
        private readonly MatureFashionsContext _context;

        public FranchisorsController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Franchisors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Franchisor.ToListAsync());
        }

        // GET: Franchisors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchisor = await _context.Franchisor
                .FirstOrDefaultAsync(m => m.FranchisorNo == id);
            if (franchisor == null)
            {
                return NotFound();
            }

            return View(franchisor);
        }

        // GET: Franchisors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchisorNo,FranchisorName,FranchisorAddress,FranchisorPostcode,FranchisorTel,FranchisorFax")] Franchisor franchisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchisor);
        }

        // GET: Franchisors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchisor = await _context.Franchisor.FindAsync(id);
            if (franchisor == null)
            {
                return NotFound();
            }
            return View(franchisor);
        }

        // POST: Franchisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchisorNo,FranchisorName,FranchisorAddress,FranchisorPostcode,FranchisorTel,FranchisorFax")] Franchisor franchisor)
        {
            if (id != franchisor.FranchisorNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchisorExists(franchisor.FranchisorNo))
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
            return View(franchisor);
        }

        // GET: Franchisors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchisor = await _context.Franchisor
                .FirstOrDefaultAsync(m => m.FranchisorNo == id);
            if (franchisor == null)
            {
                return NotFound();
            }

            return View(franchisor);
        }

        // POST: Franchisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var franchisor = await _context.Franchisor.FindAsync(id);
            _context.Franchisor.Remove(franchisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchisorExists(string id)
        {
            return _context.Franchisor.Any(e => e.FranchisorNo == id);
        }
    }
}
