using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IspProject.Models;
using IspProject.Services.PotentialClient;
using IspProject.DTOs;

namespace IspProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotentialClientController : ControllerBase
    {
        private readonly AccountDbContext _context;
        private readonly IPotentialClientService _potentialClientService;

        public PotentialClientController(AccountDbContext context, IPotentialClientService potentialClientService)
        {
            _context = context;
            _potentialClientService = potentialClientService;
        }

        // GET: api/PotentialClient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PotentialClient>>> GetpotentialClients()
        {
          if (_context.potentialClients == null)
          {
              return NotFound();
          }
            return await _context.potentialClients.ToListAsync();
        }

        // GET: api/PotentialClient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PotentialClient>> GetPotentialClient(int id)
        {
          if (_context.potentialClients == null)
          {
              return NotFound();
          }
            var potentialClient = await _context.potentialClients.FindAsync(id);

            if (potentialClient == null)
            {
                return NotFound();
            }

            return potentialClient;
        }

        // PUT: api/PotentialClient/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPotentialClient(int id, PotentialClient potentialClient)
        {
            if (id != potentialClient.idPotentialClient)
            {
                return BadRequest();
            }

            _context.Entry(potentialClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PotentialClientExists(id))
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

        // POST: api/PotentialClient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PotentialClient>> CreatePotentialClient(CreatePotentialClientRequest request)
        {
            var response = await _potentialClientService.CreatePotentialClient(request);
            return CreatedAtAction(nameof(CreatePotentialClient), response);
        }

        // DELETE: api/PotentialClient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePotentialClient(int id)
        {
            if (_context.potentialClients == null)
            {
                return NotFound();
            }
            var potentialClient = await _context.potentialClients.FindAsync(id);
            if (potentialClient == null)
            {
                return NotFound();
            }

            _context.potentialClients.Remove(potentialClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PotentialClientExists(int id)
        {
            return (_context.potentialClients?.Any(e => e.idPotentialClient == id)).GetValueOrDefault();
        }
    }
}
