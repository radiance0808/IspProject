using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IspProject.Models;

namespace IspProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public SupportTicketController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/SupportTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetsupportTickets()
        {
          if (_context.supportTickets == null)
          {
              return NotFound();
          }
            return await _context.supportTickets.ToListAsync();
        }

        // GET: api/SupportTicket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicket>> GetSupportTicket(int id)
        {
          if (_context.supportTickets == null)
          {
              return NotFound();
          }
            var supportTicket = await _context.supportTickets.FindAsync(id);

            if (supportTicket == null)
            {
                return NotFound();
            }

            return supportTicket;
        }

        // PUT: api/SupportTicket/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportTicket(int id, SupportTicket supportTicket)
        {
            if (id != supportTicket.idSupportTicket)
            {
                return BadRequest();
            }

            _context.Entry(supportTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SupportTicket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupportTicket>> PostSupportTicket(SupportTicket supportTicket)
        {
          if (_context.supportTickets == null)
          {
              return Problem("Entity set 'AccountDbContext.supportTickets'  is null.");
          }
            _context.supportTickets.Add(supportTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupportTicket", new { id = supportTicket.idSupportTicket }, supportTicket);
        }

        // DELETE: api/SupportTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportTicket(int id)
        {
            if (_context.supportTickets == null)
            {
                return NotFound();
            }
            var supportTicket = await _context.supportTickets.FindAsync(id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            _context.supportTickets.Remove(supportTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportTicketExists(int id)
        {
            return (_context.supportTickets?.Any(e => e.idSupportTicket == id)).GetValueOrDefault();
        }
    }
}
