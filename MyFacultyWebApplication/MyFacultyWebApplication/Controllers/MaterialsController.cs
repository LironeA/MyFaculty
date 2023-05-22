<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Controllers
{
<<<<<<< HEAD
    [Authorize(Roles = "admin")]
=======
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
    public class MaterialsController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public MaterialsController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
            var materials = _context.Materials.Include(m => m.Subject);
            return View(await materials.ToListAsync());
=======
            var myFacultyDbContext = _context.Materials.Include(m => m.Subject);
            return View(await myFacultyDbContext.ToListAsync());
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materials == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materials/Create
<<<<<<< HEAD
        public IActionResult Create(int subjectId = -1)
        {
            if (subjectId == -1)
            {
                ViewData["AddToSubject"] = false;
                ViewData["SubjectList"] = new SelectList(_context.Subjects, "Id", "Abbreviation");
                return View();
            }
            ViewData["AddToSubject"] = true;
            ViewData["SubjectId"] = subjectId;
            return View();
        }


=======
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation");
            return View();
        }

>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url,SubjectId")] Material material)
        {
<<<<<<< HEAD
            material.Subject = await _context.Subjects.SingleAsync(s => s.Id == material.SubjectId);

=======
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation", material.SubjectId);
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materials == null)
            {
                return NotFound();
            }

            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation", material.SubjectId);
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,SubjectId")] Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation", material.SubjectId);
            return View(material);
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materials == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materials == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.Materials'  is null.");
            }
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return (_context.Materials?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
