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
    public class AdressController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public AdressController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/Adress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Getadresses()
        {
          if (_context.addresses == null)
          {
              return NotFound();
          }
            return await _context.addresses.ToListAsync();
        }

        // GET: api/Adress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAdress(int id)
        {
          if (_context.addresses == null)
          {
              return NotFound();
          }
            var adress = await _context.addresses.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }

        // PUT: api/Adress/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdress(int id, Address adress)
        {
            if (id != adress.idAddress)
            {
                return BadRequest();
            }

            _context.Entry(adress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
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

        // POST: api/Adress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAdress(Address address)
        {
          if (_context.addresses == null)
          {
              return Problem("Entity set 'AccountDbContext.adresses'  is null.");
          }
            _context.addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdress", new { id = address.idAddress }, address);
        }

        // DELETE: api/Adress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            if (_context.addresses == null)
            {
                return NotFound();
            }
            var adress = await _context.addresses.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }

            _context.addresses.Remove(adress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdressExists(int id)
        {
            return (_context.addresses?.Any(e => e.idAddress == id)).GetValueOrDefault();
        }
    }
}
