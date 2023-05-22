<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Controllers
{
    public class TeachersController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public TeachersController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
              return _context.Teachers != null ? 
                          View(await _context.Teachers.ToListAsync()) :
                          Problem("Entity set 'MyFacultyDbContext.Teachers'  is null.");
=======
            var myFacultyDbContext = _context.Teachers.Include(t => t.Degree);
            return View(await myFacultyDbContext.ToListAsync());
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
<<<<<<< HEAD
=======
                .Include(t => t.Degree)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            ViewData["Degrees"] = new SelectList(_context.Degrees, "Id", "Name");

=======
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
<<<<<<< HEAD
=======
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Name");
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,LastName,DateOfBirth,DegreeId,UserId")] Teacher teacher)
=======
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,LastName,DateOfBirth,DegreeId")] Teacher teacher)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
<<<<<<< HEAD
=======
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Name", teacher.DegreeId);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
=======
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Name", teacher.DegreeId);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,LastName,DateOfBirth,DegreeId,UserId")] Teacher teacher)
=======
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,LastName,DateOfBirth,DegreeId")] Teacher teacher)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
<<<<<<< HEAD
=======
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Name", teacher.DegreeId);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
<<<<<<< HEAD
=======
                .Include(t => t.Degree)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teachers == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.Teachers'  is null.");
            }
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }
<<<<<<< HEAD
            
=======

>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
<<<<<<< HEAD
          return (_context.Teachers?.Any(e => e.Id == id)).GetValueOrDefault();
=======
            return (_context.Teachers?.Any(e => e.Id == id)).GetValueOrDefault();
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }
    }
}
