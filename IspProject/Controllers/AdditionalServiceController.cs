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
    public class AdditionalServiceController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public AdditionalServiceController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/AdditionalService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalService>>> GetadditionalServices()
        {
          if (_context.additionalServices == null)
          {
              return NotFound();
          }
            return await _context.additionalServices.ToListAsync();
        }

        // GET: api/AdditionalService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalService>> GetAdditionalService(int id)
        {
          if (_context.additionalServices == null)
          {
              return NotFound();
          }
            var additionalService = await _context.additionalServices.FindAsync(id);

            if (additionalService == null)
            {
                return NotFound();
            }

            return additionalService;
        }

        // PUT: api/AdditionalService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditionalService(int id, AdditionalService additionalService)
        {
            if (id != additionalService.idAdditionalService)
            {
                return BadRequest();
            }

            _context.Entry(additionalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalServiceExists(id))
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

        // POST: api/AdditionalService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdditionalService>> PostAdditionalService(AdditionalService additionalService)
        {
          if (_context.additionalServices == null)
          {
              return Problem("Entity set 'AccountDbContext.additionalServices'  is null.");
          }
            _context.additionalServices.Add(additionalService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditionalService", new { id = additionalService.idAdditionalService }, additionalService);
        }

        // DELETE: api/AdditionalService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditionalService(int id)
        {
            if (_context.additionalServices == null)
            {
                return NotFound();
            }
            var additionalService = await _context.additionalServices.FindAsync(id);
            if (additionalService == null)
            {
                return NotFound();
            }

            _context.additionalServices.Remove(additionalService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdditionalServiceExists(int id)
        {
            return (_context.additionalServices?.Any(e => e.idAdditionalService == id)).GetValueOrDefault();
        }
    }
}
