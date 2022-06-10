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
    public class TypeOfHouseController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public TypeOfHouseController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfHouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfHouse>>> GettypeHouses()
        {
          if (_context.typeHouses == null)
          {
              return NotFound();
          }
            return await _context.typeHouses.ToListAsync();
        }

        // GET: api/TypeOfHouse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfHouse>> GetTypeOfHouse(int id)
        {
          if (_context.typeHouses == null)
          {
              return NotFound();
          }
            var typeOfHouse = await _context.typeHouses.FindAsync(id);

            if (typeOfHouse == null)
            {
                return NotFound();
            }

            return typeOfHouse;
        }

        // PUT: api/TypeOfHouse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfHouse(int id, TypeOfHouse typeOfHouse)
        {
            if (id != typeOfHouse.idTypeOfHouse)
            {
                return BadRequest();
            }

            _context.Entry(typeOfHouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfHouseExists(id))
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

        // POST: api/TypeOfHouse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeOfHouse>> PostTypeOfHouse(TypeOfHouse typeOfHouse)
        {
          if (_context.typeHouses == null)
          {
              return Problem("Entity set 'AccountDbContext.typeHouses'  is null.");
          }
            _context.typeHouses.Add(typeOfHouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeOfHouse", new { id = typeOfHouse.idTypeOfHouse }, typeOfHouse);
        }

        // DELETE: api/TypeOfHouse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfHouse(int id)
        {
            if (_context.typeHouses == null)
            {
                return NotFound();
            }
            var typeOfHouse = await _context.typeHouses.FindAsync(id);
            if (typeOfHouse == null)
            {
                return NotFound();
            }

            _context.typeHouses.Remove(typeOfHouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeOfHouseExists(int id)
        {
            return (_context.typeHouses?.Any(e => e.idTypeOfHouse == id)).GetValueOrDefault();
        }
    }
}
