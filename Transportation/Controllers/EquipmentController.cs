using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transportation.Data;
using Transportation.Models;

namespace Transportation.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly blonddachshund _context;

        public EquipmentController(blonddachshund context)
        {
            _context = context;
        }

        // GET: Equipment
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Equipment.Include(e => e.Route).Include(e => e.Ticket).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equipment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Route)
                .Include(e => e.Ticket)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipment/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Equipment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designator,Type,Status,StatusNote,Replacement,DOT,Note,Radio,RadioNote,DVR,BuiltIns,Wheelchair,VIN,CapacityAdult,CapacityChild,Location,Published,Inactive,Select,Created,Publc,RouteId,TicketId,UserId")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", equipment.RouteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", equipment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", equipment.UserId);
            return View(equipment);
        }

        // GET: Equipment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", equipment.RouteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", equipment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", equipment.UserId);
            return View(equipment);
        }

        // POST: Equipment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designator,Type,Status,StatusNote,Replacement,DOT,Note,Radio,RadioNote,DVR,BuiltIns,Wheelchair,VIN,CapacityAdult,CapacityChild,Location,Published,Inactive,Select,Created,Publc,RouteId,TicketId,UserId")] Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.Id))
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
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", equipment.RouteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", equipment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", equipment.UserId);
            return View(equipment);
        }

        // GET: Equipment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Route)
                .Include(e => e.Ticket)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Equipment'  is null.");
            }
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
          return (_context.Equipment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
