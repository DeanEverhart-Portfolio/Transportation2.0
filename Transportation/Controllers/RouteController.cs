//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Transportation.Data;
//using Transportation.Models;

//namespace Transportation.Controllers
//{
//    public class RouteController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public RouteController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Route
//        public async Task<IActionResult> Index()
//        {
//            var applicationDbContext = _context.Route.Include(r => r.Ticket).Include(r => r.User);
//            return View(await applicationDbContext.ToListAsync());
//        }

//        // GET: Route/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Route == null)
//            {
//                return NotFound();
//            }

//            var route = await _context.Route
//                .Include(r => r.Ticket)
//                .Include(r => r.User)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (route == null)
//            {
//                return NotFound();
//            }

//            return View(route);
//        }

//        // GET: Route/Create
//        public IActionResult Create()
//        {
//            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
//            return View();
//        }

//        // POST: Route/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Designator,District,DayOfWeek,Hardware,Supervision,AmReport,AmLeave,AmArrive,PmReport,Published,Inactive,Select,Created,Publc,TicketId,UserId")] Route route)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(route);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", route.TicketId);
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", route.UserId);
//            return View(route);
//        }

//        // GET: Route/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Route == null)
//            {
//                return NotFound();
//            }

//            var route = await _context.Route.FindAsync(id);
//            if (route == null)
//            {
//                return NotFound();
//            }
//            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", route.TicketId);
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", route.UserId);
//            return View(route);
//        }

//        // POST: Route/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Designator,District,DayOfWeek,Hardware,Supervision,AmReport,AmLeave,AmArrive,PmReport,Published,Inactive,Select,Created,Publc,TicketId,UserId")] Route route)
//        {
//            if (id != route.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(route);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RouteExists(route.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", route.TicketId);
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", route.UserId);
//            return View(route);
//        }

//        // GET: Route/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Route == null)
//            {
//                return NotFound();
//            }

//            var route = await _context.Route
//                .Include(r => r.Ticket)
//                .Include(r => r.User)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (route == null)
//            {
//                return NotFound();
//            }

//            return View(route);
//        }

//        // POST: Route/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Route == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.Route'  is null.");
//            }
//            var route = await _context.Route.FindAsync(id);
//            if (route != null)
//            {
//                _context.Route.Remove(route);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool RouteExists(int id)
//        {
//            return (_context.Route?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
