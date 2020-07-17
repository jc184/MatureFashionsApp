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
    public class HometypesController : Controller
    {
        private readonly MatureFashionsContext _context;

        public HometypesController(MatureFashionsContext context)
        {
            _context = context;
        }

        // GET: Hometypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hometype.ToListAsync());
        }

        // GET: Hometypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometype = await _context.Hometype
                .FirstOrDefaultAsync(m => m.HometypeCode == id);
            if (hometype == null)
            {
                return NotFound();
            }

            return View(hometype);
        }

        // GET: Hometypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hometypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HometypeCode,HometypeDescription")] Hometype hometype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hometype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hometype);
        }

        // GET: Hometypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometype = await _context.Hometype.FindAsync(id);
            if (hometype == null)
            {
                return NotFound();
            }
            return View(hometype);
        }

        // POST: Hometypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HometypeCode,HometypeDescription")] Hometype hometype)
        {
            if (id != hometype.HometypeCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hometype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HometypeExists(hometype.HometypeCode))
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
            return View(hometype);
        }

        // GET: Hometypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometype = await _context.Hometype
                .FirstOrDefaultAsync(m => m.HometypeCode == id);
            if (hometype == null)
            {
                return NotFound();
            }

            return View(hometype);
        }

        // POST: Hometypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hometype = await _context.Hometype.FindAsync(id);
            _context.Hometype.Remove(hometype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HometypeExists(string id)
        {
            return _context.Hometype.Any(e => e.HometypeCode == id);
        }
    }
}
