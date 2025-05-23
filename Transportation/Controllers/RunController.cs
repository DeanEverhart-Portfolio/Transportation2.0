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
    public class RunController : Controller
    {
        private readonly blonddachshund _context;

        public RunController(blonddachshund context)
        {
            _context = context;
        }

        // GET: Run
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Run.Include(r => r.Route).Include(r => r.Ticket).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Run/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Run == null)
            {
                return NotFound();
            }

            var run = await _context.Run
                .Include(r => r.Route)
                .Include(r => r.Ticket)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // GET: Run/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Run/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designator,AmStart,PmStart,AmArrive,PmArrive,Sequence,DayOfWeek,District,School,Hardware,Supervision,Published,Inactive,Select,Created,Publc,RouteId,TicketId,UserId")] Run run)
        {
            if (ModelState.IsValid)
            {
                _context.Add(run);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", run.RouteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", run.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", run.UserId);
            return View(run);
        }

        // GET: Run/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Run == null)
            {
                return NotFound();
            }

            var run = await _context.Run.FindAsync(id);
            if (run == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", run.RouteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", run.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", run.UserId);
            return View(run);
        }

        // POST: Run/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designator,AmStart,PmStart,AmArrive,PmArrive,Sequence,DayOfWeek,District,School,Hardware,Supervision,Published,Inactive,Select,Created,Publc,RouteId,TicketId,UserId")] Run run)
        {
            if (id != run.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(run);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunExists(run.Id))
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
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", run.RouteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", run.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", run.UserId);
            return View(run);
        }

        // GET: Run/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Run == null)
            {
                return NotFound();
            }

            var run = await _context.Run
                .Include(r => r.Route)
                .Include(r => r.Ticket)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // POST: Run/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Run == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Run'  is null.");
            }
            var run = await _context.Run.FindAsync(id);
            if (run != null)
            {
                _context.Run.Remove(run);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunExists(int id)
        {
          return (_context.Run?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
