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
    public class TrafficController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public TrafficController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/Traffic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Traffic>>> Gettraffics()
        {
          if (_context.traffics == null)
          {
              return NotFound();
          }
            return await _context.traffics.ToListAsync();
        }

        // GET: api/Traffic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Traffic>> GetTraffic(int id)
        {
          if (_context.traffics == null)
          {
              return NotFound();
          }
            var traffic = await _context.traffics.FindAsync(id);

            if (traffic == null)
            {
                return NotFound();
            }

            return traffic;
        }

        // PUT: api/Traffic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraffic(int id, Traffic traffic)
        {
            if (id != traffic.idTraffic)
            {
                return BadRequest();
            }

            _context.Entry(traffic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrafficExists(id))
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

        // POST: api/Traffic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Traffic>> PostTraffic(Traffic traffic)
        {
          if (_context.traffics == null)
          {
              return Problem("Entity set 'AccountDbContext.traffics'  is null.");
          }
            _context.traffics.Add(traffic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraffic", new { id = traffic.idTraffic }, traffic);
        }

        // DELETE: api/Traffic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraffic(int id)
        {
            if (_context.traffics == null)
            {
                return NotFound();
            }
            var traffic = await _context.traffics.FindAsync(id);
            if (traffic == null)
            {
                return NotFound();
            }

            _context.traffics.Remove(traffic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrafficExists(int id)
        {
            return (_context.traffics?.Any(e => e.idTraffic == id)).GetValueOrDefault();
        }
    }
}
