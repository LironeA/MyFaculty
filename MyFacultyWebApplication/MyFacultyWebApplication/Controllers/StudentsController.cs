<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;
using System.Data;

namespace MyFacultyWebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentsController : Controller
    {
        MyFacultyDbContext _context;
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MyFacultyDbContext _context;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

        public StudentsController(MyFacultyDbContext context)
        {
            _context = context;
        }
<<<<<<< HEAD
        
        public async Task<IActionResult> Index()
        {
            var students = _context.Students.Include(m => m.Group);
            return View(await students.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
=======

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var myFacultyDbContext = _context.Students.Include(s => s.Group).Include(s => s.Status);
            return View(await myFacultyDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            var student = await _context.Students
                .Include(m => m.Group)
=======

            var student = await _context.Students
                .Include(s => s.Group)
                .Include(s => s.Status)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["GroupList"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Surname, LastName, DateOfBirth, GroupId, StatusId")] Student student)
        {
            student.Group = await _context.Groups.FindAsync(student.GroupId);
            var status = await _context.Statuses.FirstAsync(s => s.Name == "Inactive");
            student.StatusId = status.Id;
            student.Status = status;

=======

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,LastName,DateOfBirth,GroupId,StatusId")] Student student)
        {
            var status = await _context.Statuses.SingleAsync(s => s.Id == student.StatusId);
            student.Status = status;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
<<<<<<< HEAD
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

=======
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", student.GroupId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", student.StatusId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            ViewData["GroupList"] = new SelectList(_context.Groups, "Id", "Name");
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
=======
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", student.GroupId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", student.StatusId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,LastName,DateOfBirth,GroupId,StatusId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            
            var status = _context.Statuses.Single(s => s.Id == student.StatusId);
            student.Status = status;
            var group = _context.Groups.Single(g => g.Id == student.GroupId);
            student.Group = group;
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", student.GroupId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", student.StatusId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var student = await _context.Students.FindAsync(id);

=======
            var student = await _context.Students
                .Include(s => s.Group)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

<<<<<<< HEAD
=======
        // POST: Students/Delete/5
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
<<<<<<< HEAD
=======

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
    }
}
