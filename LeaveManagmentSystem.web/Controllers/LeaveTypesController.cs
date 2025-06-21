using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.web.Data;

namespace LeaveManagmentSystem.web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypesController(ApplicationDbContext context)
        {
            // dependency injection, this will create local db connection to the database
            _context = context;
        }

        // GET: LeavTypes
        public async Task<IActionResult> Index()
        {
            // the bellow stmt represents var data = select * from LeavTypes
            var data = await _context.LeavTypes.ToListAsync();
            return View(data);
        }

        // GET: LeavTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavType = await _context.LeavTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leavType == null)
            {
                return NotFound();
            }

            return View(leavType);
        }

        // GET: LeavTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeavTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NumberOfDays")] LeaveType leavType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leavType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leavType);
        }

        // GET: LeavTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavType = await _context.LeavTypes.FindAsync(id);
            if (leavType == null)
            {
                return NotFound();
            }
            return View(leavType);
        }

        // POST: LeavTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfDays")] LeaveType leavType)
        {
            if (id != leavType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leavType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeavTypeExists(leavType.Id))
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
            return View(leavType);
        }

        // GET: LeavTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavType = await _context.LeavTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leavType == null)
            {
                return NotFound();
            }

            return View(leavType);
        }

        // POST: LeavTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leavType = await _context.LeavTypes.FindAsync(id);
            if (leavType != null)
            {
                _context.LeavTypes.Remove(leavType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeavTypeExists(int id)
        {
            return _context.LeavTypes.Any(e => e.Id == id);
        }
    }
}
