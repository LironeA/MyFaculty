using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFacultyWebApplication.Models;
using NuGet.Versioning;

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
              return _context.Groups != null ? 
                          View(await _context.Groups.ToListAsync()) :
                          Problem("Entity set 'MyFacultyDbContext.Groups'  is null.");
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            ViewData["Specialty"] = await _context.Specialties.SingleOrDefaultAsync(g => g.Id == group.SpecialtyId);

            return View(@group);
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
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SpecialtyId")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
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
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
          return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
