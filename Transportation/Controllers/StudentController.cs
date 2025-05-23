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
    public class StudentController : Controller
    {
        private readonly blonddachshund _context;

        public StudentController(blonddachshund context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student.Include(s => s.Run).Include(s => s.Ticket).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Run)
                .Include(s => s.Ticket)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,AreaCode,Prefix,Line,Extension,PhoneLabel,Gatekeeper,GatekeeperNote,PhoneNote,PhoneSort,AreaCode2,Prefix2,Line2,Extension2,Phone2Label,Gatekeeper2,Gatekeeper2Note,Phone2Note,Phone2Sort,AreaCode3,Prefix3,Line3,Extension3,Phone3Label,Gatekeeper3,Gatekeeper3Note,Phone3Note,Phone3Sort,Email,EmailLabel,EmailSort,Email2,Email21Label,Email2Sort,Email3,Email2Label,Email3Sort,Domain,Domain1,Website,WebsiteLabel,Website2,Website2Label,Website3,Website3Label,StreetNumber,StreetName,StreetDesignator,Street2,TownCity,State,ZipCode,County,Country,Map,Published,Inactive,Select,Created,Publc,RunId,TicketId,UserId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", student.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", student.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", student.UserId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", student.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", student.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", student.UserId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,AreaCode,Prefix,Line,Extension,PhoneLabel,Gatekeeper,GatekeeperNote,PhoneNote,PhoneSort,AreaCode2,Prefix2,Line2,Extension2,Phone2Label,Gatekeeper2,Gatekeeper2Note,Phone2Note,Phone2Sort,AreaCode3,Prefix3,Line3,Extension3,Phone3Label,Gatekeeper3,Gatekeeper3Note,Phone3Note,Phone3Sort,Email,EmailLabel,EmailSort,Email2,Email21Label,Email2Sort,Email3,Email2Label,Email3Sort,Domain,Domain1,Website,WebsiteLabel,Website2,Website2Label,Website3,Website3Label,StreetNumber,StreetName,StreetDesignator,Street2,TownCity,State,ZipCode,County,Country,Map,Published,Inactive,Select,Created,Publc,RunId,TicketId,UserId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

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
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", student.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", student.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", student.UserId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Run)
                .Include(s => s.Ticket)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
