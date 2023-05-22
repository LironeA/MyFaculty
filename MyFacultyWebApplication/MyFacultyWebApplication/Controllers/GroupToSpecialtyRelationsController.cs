using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Controllers
{
    public class GroupToSpecialtyRelationsController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public GroupToSpecialtyRelationsController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: GroupToSpecialtyRelations
        public async Task<IActionResult> Index()
        {
            var myFacultyDbContext = _context.GroupToSpecialtyRelations.Include(g => g.Group).Include(g => g.Specialty);
            return View(await myFacultyDbContext.ToListAsync());
        }

        // GET: GroupToSpecialtyRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GroupToSpecialtyRelations == null)
            {
                return NotFound();
            }

            var groupToSpecialtyRelation = await _context.GroupToSpecialtyRelations
                .Include(g => g.Group)
                .Include(g => g.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupToSpecialtyRelation == null)
            {
                return NotFound();
            }

            return View(groupToSpecialtyRelation);
        }

        // GET: GroupToSpecialtyRelations/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name");
            return View();
        }

        // POST: GroupToSpecialtyRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupId,SpecialtyId")] GroupToSpecialtyRelation groupToSpecialtyRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupToSpecialtyRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", groupToSpecialtyRelation.GroupId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", groupToSpecialtyRelation.SpecialtyId);
            return View(groupToSpecialtyRelation);
        }

        // GET: GroupToSpecialtyRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GroupToSpecialtyRelations == null)
            {
                return NotFound();
            }

            var groupToSpecialtyRelation = await _context.GroupToSpecialtyRelations.FindAsync(id);
            if (groupToSpecialtyRelation == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", groupToSpecialtyRelation.GroupId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", groupToSpecialtyRelation.SpecialtyId);
            return View(groupToSpecialtyRelation);
        }

        // POST: GroupToSpecialtyRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupId,SpecialtyId")] GroupToSpecialtyRelation groupToSpecialtyRelation)
        {
            if (id != groupToSpecialtyRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupToSpecialtyRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupToSpecialtyRelationExists(groupToSpecialtyRelation.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", groupToSpecialtyRelation.GroupId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", groupToSpecialtyRelation.SpecialtyId);
            return View(groupToSpecialtyRelation);
        }

        // GET: GroupToSpecialtyRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GroupToSpecialtyRelations == null)
            {
                return NotFound();
            }

            var groupToSpecialtyRelation = await _context.GroupToSpecialtyRelations
                .Include(g => g.Group)
                .Include(g => g.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupToSpecialtyRelation == null)
            {
                return NotFound();
            }

            return View(groupToSpecialtyRelation);
        }

        // POST: GroupToSpecialtyRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GroupToSpecialtyRelations == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.GroupToSpecialtyRelations'  is null.");
            }
            var groupToSpecialtyRelation = await _context.GroupToSpecialtyRelations.FindAsync(id);
            if (groupToSpecialtyRelation != null)
            {
                _context.GroupToSpecialtyRelations.Remove(groupToSpecialtyRelation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupToSpecialtyRelationExists(int id)
        {
          return (_context.GroupToSpecialtyRelations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
