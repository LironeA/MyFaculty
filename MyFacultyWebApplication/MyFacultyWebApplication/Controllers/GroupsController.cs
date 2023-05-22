<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;
using NuGet.Versioning;
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

namespace MyFacultyWebApplication.Controllers
{
    public class GroupsController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public GroupsController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
              return _context.Groups != null ? 
                          View(await _context.Groups.ToListAsync()) :
                          Problem("Entity set 'MyFacultyDbContext.Groups'  is null.");
=======
                var groups = _context.Groups.Include(g => g.Specialty);
                return View(await groups.ToListAsync());
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            ViewData["Specialty"] = await _context.Specialties.SingleOrDefaultAsync(g => g.Id == group.SpecialtyId);

            return View(@group);
=======
            var group = await _context.Groups
                .Include(g => g.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            var students = await _context.Students.Where(s => s.GroupId == group.Id).ToListAsync();
            ViewBag.Students = students;
            return View(group);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create([Bind("Id,Name,SpecialtyId")] Group @group)
        {
            var specialty = await _context.Specialties.SingleOrDefaultAsync(g => g.Id == group.SpecialtyId);
            group.Specialty = specialty;
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                await _context.SaveChangesAsync();
                
                var relation = new GroupToSpecialtyRelation();
                relation.SpecialtyId = specialty.Id;
                relation.Specialty = specialty;
                relation.GroupId = @group.Id;
                relation.Group = @group;
                _context.Add(relation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@group);
=======
        public async Task<IActionResult> Create([Bind("Id,Name,SpecialtyId")] Group group)
        {
            group.Specialty = _context.Specialties.Single(s => s.Id == group.SpecialtyId);

            if (ModelState.IsValid)
            {
                _context.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", group.SpecialtyId);
            return View(group);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
=======
            var ggroup = await _context.Groups.FindAsync(id);
            if (ggroup == null)
            {
                return NotFound();
            }
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", ggroup.SpecialtyId);
            return View(ggroup);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SpecialtyId")] Group @group)
        {
            if (id != @group.Id)
=======
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SpecialtyId")] Group ggroup)
        {
            if (id != ggroup.Id)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
<<<<<<< HEAD
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                    var relation = await _context.GroupToSpecialtyRelations.SingleOrDefaultAsync(gsr => gsr.GroupId == group.Id);
                    if (relation != null)
                    {
                        relation.SpecialtyId = @group.SpecialtyId;
                        _context.Update(relation);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
=======
                    _context.Update(ggroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(ggroup.Id))
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
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
            return View(@group);
=======
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", ggroup.SpecialtyId);
            return View(ggroup);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
=======
            var ggroup = await _context.Groups
                .Include(g => g.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ggroup == null)
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            {
                return NotFound();
            }

<<<<<<< HEAD
            return View(@group);
=======
            return View(ggroup);
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groups == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.Groups'  is null.");
            }
<<<<<<< HEAD
            var @group = await _context.Groups.FindAsync(id);
            var relation = await _context.GroupToSpecialtyRelations.SingleOrDefaultAsync(gsr => gsr.GroupId == group.Id);
            
            if (@group != null)
            {
                _context.Groups.Remove(@group);  
            }
            
            await _context.SaveChangesAsync();
            if (relation != null)
            {
                relation.SpecialtyId = @group.SpecialtyId;
                _context.Update(relation);
                await _context.SaveChangesAsync();
            }
=======
            var ggroup = await _context.Groups.FindAsync(id);
            if (ggroup != null)
            {
                _context.Groups.Remove(ggroup);
            }

            await _context.SaveChangesAsync();
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
<<<<<<< HEAD
          return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
=======
            return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }


>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
    }
}
