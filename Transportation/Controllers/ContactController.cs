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
    public class ContactController : Controller
    {
        private readonly blonddachshund _context;

        public ContactController(blonddachshund context)
        {
            _context = context;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contacts.Include(c => c.Route).Include(c => c.Run).Include(c => c.Ticket).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Route)
                .Include(c => c.Run)
                .Include(c => c.Ticket)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id");
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,Company,Entity,Type,Client,License,Class,Endorsement,AMReport,PMReport,EmployeeID,AreaCode,Prefix,Line,Extension,PhoneLabel,Gatekeeper,GatekeeperNote,PhoneNote,PhoneSort,AreaCode2,Prefix2,Line2,Extension2,Phone2Label,Gatekeeper2,Gatekeeper2Note,Phone2Note,Phone2Sort,AreaCode3,Prefix3,Line3,Extension3,Phone3Label,Gatekeeper3,Gatekeeper3Note,Phone3Note,Phone3Sort,Email,EmailLabel,EmailSort,Email2,Email21Label,Email2Sort,Email3,Email2Label,Email3Sort,Domain,Domain1,Website,WebsiteLabel,Website2,Website2Label,Website3,Website3Label,StreetNumber,StreetName,StreetDesignator,Street2,TownCity,State,ZipCode,County,Country,Map,Published,Inactive,Select,Created,Publc,RouteId,RunId,TicketId,UserId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", contact.RouteId);
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", contact.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", contact.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contact.UserId);
            return View(contact);
        }

        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", contact.RouteId);
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", contact.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", contact.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contact.UserId);
            return View(contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,Company,Entity,Type,Client,License,Class,Endorsement,AMReport,PMReport,EmployeeID,AreaCode,Prefix,Line,Extension,PhoneLabel,Gatekeeper,GatekeeperNote,PhoneNote,PhoneSort,AreaCode2,Prefix2,Line2,Extension2,Phone2Label,Gatekeeper2,Gatekeeper2Note,Phone2Note,Phone2Sort,AreaCode3,Prefix3,Line3,Extension3,Phone3Label,Gatekeeper3,Gatekeeper3Note,Phone3Note,Phone3Sort,Email,EmailLabel,EmailSort,Email2,Email21Label,Email2Sort,Email3,Email2Label,Email3Sort,Domain,Domain1,Website,WebsiteLabel,Website2,Website2Label,Website3,Website3Label,StreetNumber,StreetName,StreetDesignator,Street2,TownCity,State,ZipCode,County,Country,Map,Published,Inactive,Select,Created,Publc,RouteId,RunId,TicketId,UserId")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Id", contact.RouteId);
            ViewData["RunId"] = new SelectList(_context.Run, "Id", "Id", contact.RunId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id", contact.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contact.UserId);
            return View(contact);
        }

        // GET: Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Route)
                .Include(c => c.Run)
                .Include(c => c.Ticket)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
          return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
