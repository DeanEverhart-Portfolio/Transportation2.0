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
    public class CalendarController : Controller
    {
        private readonly blonddachshund _context;

        public CalendarController(blonddachshund context)
        {
            _context = context;
        }

        // GET: Calendar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Calendars.Include(c => c.Contact).Include(c => c.Route).Include(c => c.Run).Include(c => c.Ticket).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Calendar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calendars == null)
            {
                return NotFound();
            }

            var calendar = await _context.Calendars
                .Include(c => c.Contact)
                .Include(c => c.Route)
                .Include(c => c.Run)
                .Include(c => c.Ticket)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendar == null)
            {
                return NotFound();
            }

            return View(calendar);
        }

        // GET: Calendar/Create
        public IActionResult Create()
        {
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id");
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id");
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Calendar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,DayOfWeek,Item,Event,Dismissal,Return,ReturnDayOfWeek,Type,SubType,Published,Inactive,Select,Created,Publc,ContactId,RouteId,RunId,TicketId,UserId")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", calendar.ContactId);
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", calendar.RouteId);
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", calendar.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", calendar.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", calendar.UserId);
            return View(calendar);
        }

        // GET: Calendar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calendars == null)
            {
                return NotFound();
            }

            var calendar = await _context.Calendars.FindAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", calendar.ContactId);
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", calendar.RouteId);
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", calendar.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", calendar.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", calendar.UserId);
            return View(calendar);
        }

        // POST: Calendar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,DayOfWeek,Item,Event,Dismissal,Return,ReturnDayOfWeek,Type,SubType,Published,Inactive,Select,Created,Publc,ContactId,RouteId,RunId,TicketId,UserId")] Calendar calendar)
        {
            if (id != calendar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarExists(calendar.Id))
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
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", calendar.ContactId);
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", calendar.RouteId);
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", calendar.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", calendar.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", calendar.UserId);
            return View(calendar);
        }

        // GET: Calendar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calendars == null)
            {
                return NotFound();
            }

            var calendar = await _context.Calendars
                .Include(c => c.Contact)
                .Include(c => c.Route)
                .Include(c => c.Run)
                .Include(c => c.Ticket)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendar == null)
            {
                return NotFound();
            }

            return View(calendar);
        }

        // POST: Calendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calendars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Calendars'  is null.");
            }
            var calendar = await _context.Calendars.FindAsync(id);
            if (calendar != null)
            {
                _context.Calendars.Remove(calendar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarExists(int id)
        {
          return (_context.Calendars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
