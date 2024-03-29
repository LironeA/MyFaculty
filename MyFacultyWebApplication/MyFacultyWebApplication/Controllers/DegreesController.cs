<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Controllers
{
    public class DegreesController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public DegreesController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: Degrees
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
              return _context.Degrees != null ? 
                          View(await _context.Degrees.ToListAsync()) :
                          Problem("Entity set 'MyFacultyDbContext.Degrees'  is null.");
=======
            return _context.Degrees != null ?
                        View(await _context.Degrees.ToListAsync()) :
                        Problem("Entity set 'MyFacultyDbContext.Degrees'  is null.");
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Degrees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // GET: Degrees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(degree);
        }

        // GET: Degrees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Degree degree)
        {
            if (id != degree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeExists(degree.Id))
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
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Degrees == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.Degrees'  is null.");
            }
            var degree = await _context.Degrees.FindAsync(id);
            if (degree != null)
            {
                _context.Degrees.Remove(degree);
            }
<<<<<<< HEAD
            
=======

>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeExists(int id)
        {
<<<<<<< HEAD
          return (_context.Degrees?.Any(e => e.Id == id)).GetValueOrDefault();
=======
            return (_context.Degrees?.Any(e => e.Id == id)).GetValueOrDefault();
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }
    }
}
