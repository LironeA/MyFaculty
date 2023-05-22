<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication;
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public SubjectsController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
              return _context.Subjects != null ? 
                          View(await _context.Subjects.ToListAsync()) :
                          Problem("Entity set 'MyFacultyDbContext.Subjects'  is null.");
=======
            return _context.Subjects != null ?
                        View(await _context.Subjects.ToListAsync()) :
                        Problem("Entity set 'MyFacultyDbContext.Subjects'  is null.");
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
<<<<<<< HEAD
            if (id == null || _context.Subjects == null) return NotFound();

            var subject = await _context.Subjects.FirstOrDefaultAsync(m => m.Id == id);

            if (subject == null) return NotFound();

            ViewBag.Teachers = await _context.TeacherToSubjectRelations.Where(m => m.SubjectId == id).Select(g => g.Teacher).ToListAsync();
            ViewBag.Materials = await _context.Materials.Where(m => m.SubjectId == id).ToListAsync();
=======
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == id);

            ViewBag.Materials = _context.Materials.Where(m => m.SubjectId == id);
            var TeachersId = _context.TeacherToSubjectRelations.Where(m => m.SubjectId == id).Select(m => m.TeacherId);
            ViewBag.Teachers = _context.Teachers.Where(m => TeachersId.Contains(m.Id));
            if (subject == null)
            {
                return NotFound();
            }
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NumberOfHours,Abbreviation")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfHours,Abbreviation")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subjects == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.Subjects'  is null.");
            }
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
            }
<<<<<<< HEAD
            
=======

>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
<<<<<<< HEAD
          return (_context.Subjects?.Any(e => e.Id == id)).GetValueOrDefault();
=======
            return (_context.Subjects?.Any(e => e.Id == id)).GetValueOrDefault();
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }
    }
}
