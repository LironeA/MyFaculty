﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Controllers
{
    public class TeacherToSubjectRelationsController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public TeacherToSubjectRelationsController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: TeacherToSubjectRelations
        public async Task<IActionResult> Index()
        {
            var myFacultyDbContext = _context.TeacherToSubjectRelations.Include(t => t.Subject).Include(t => t.Teacher);
            return View(await myFacultyDbContext.ToListAsync());
        }

        // GET: TeacherToSubjectRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeacherToSubjectRelations == null)
            {
                return NotFound();
            }

            var teacherToSubjectRelation = await _context.TeacherToSubjectRelations
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherToSubjectRelation == null)
            {
                return NotFound();
            }

            return View(teacherToSubjectRelation);
        }

        // GET: TeacherToSubjectRelations/Create
        public IActionResult Create(int? subjectId)
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "LastName");
            if (subjectId==null)
            {
                ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation");
                return View();
            }
            ViewData["SubjectId"] = subjectId;
            return View();
        }

        // POST: TeacherToSubjectRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,SubjectId")] TeacherToSubjectRelation teacherToSubjectRelation)
        {
            teacherToSubjectRelation.Teacher = _context.Teachers.Single(t => t.Id == teacherToSubjectRelation.TeacherId);
            var subject = _context.Subjects.Single(s => s.Id == teacherToSubjectRelation.SubjectId);
            teacherToSubjectRelation.Subject = subject; 

            if (ModelState.IsValid)
            {
                _context.Add(teacherToSubjectRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Subjects", new { id = subject.Id });
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation", teacherToSubjectRelation.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "LastName", teacherToSubjectRelation.TeacherId);
            return View(teacherToSubjectRelation);
        }

        // GET: TeacherToSubjectRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeacherToSubjectRelations == null)
            {
                return NotFound();
            }

            var teacherToSubjectRelation = await _context.TeacherToSubjectRelations.FindAsync(id);
            if (teacherToSubjectRelation == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation", teacherToSubjectRelation.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "LastName", teacherToSubjectRelation.TeacherId);
            return View(teacherToSubjectRelation);
        }

        // POST: TeacherToSubjectRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,SubjectId")] TeacherToSubjectRelation teacherToSubjectRelation)
        {
            if (id != teacherToSubjectRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherToSubjectRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherToSubjectRelationExists(teacherToSubjectRelation.Id))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Abbreviation", teacherToSubjectRelation.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "LastName", teacherToSubjectRelation.TeacherId);
            return View(teacherToSubjectRelation);
        }

        // GET: TeacherToSubjectRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeacherToSubjectRelations == null)
            {
                return NotFound();
            }

            var teacherToSubjectRelation = await _context.TeacherToSubjectRelations
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherToSubjectRelation == null)
            {
                return NotFound();
            }

            return View(teacherToSubjectRelation);
        }

        // POST: TeacherToSubjectRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeacherToSubjectRelations == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.TeacherToSubjectRelations'  is null.");
            }
            var teacherToSubjectRelation = await _context.TeacherToSubjectRelations.FindAsync(id);
            if (teacherToSubjectRelation != null)
            {
                _context.TeacherToSubjectRelations.Remove(teacherToSubjectRelation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherToSubjectRelationExists(int id)
        {
            return (_context.TeacherToSubjectRelations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
