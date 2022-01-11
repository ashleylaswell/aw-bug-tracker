using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWBugTracker.Data;
using AWBugTracker.Entities;

namespace AWBugTracker.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Ticket
        public async Task<IActionResult> Index(int projectId)
        {
            List<Ticket> list = await (from ticket in _context.Ticket
                                       where ticket.ProjectId == projectId
                                       select new Ticket
                                       {
                                           Id = ticket.Id,
                                           Title = ticket.Title,
                                           Description = ticket.Description,
                                           ProjectId = projectId,
                                           TicketType = ticket.TicketType,
                                           TicketSeverity = ticket.TicketSeverity,
                                           Status = ticket.Status,
                                           CreatedOn = ticket.CreatedOn,
                                           ModifiedOn = ticket.ModifiedOn,
                                           
                                       }).ToListAsync();
            
            ViewBag.ProjectId = projectId;

            return View(list);
        }

        // GET: Admin/Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Admin/Ticket/Create
        public IActionResult Create(int projectId)
        {
            Ticket ticket = new Ticket
            {
                ProjectId = projectId
            };
            return View(ticket);
        }

        // POST: Admin/Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ProjectId,TicketType,TicketSeverity,Status,CreatedOn,ModifiedOn")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { projectId=ticket.ProjectId });
            }
            return View(ticket);
        }

        // GET: Admin/Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Admin/Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ProjectId,TicketType,TicketSeverity,Status,CreatedOn,ModifiedOn")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { projectId = ticket.ProjectId });
            }
            return View(ticket);
        }

        // GET: Admin/Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Admin/Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { projectId = ticket.ProjectId });
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
