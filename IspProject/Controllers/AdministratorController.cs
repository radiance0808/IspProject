using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IspProject.Models;
using IspProject.Services;

namespace IspProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly AccountDbContext _context;

        private readonly IJWTManagerRepository _jWTManager;



        public AdministratorController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/Administrator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrator>>> Getadministrators()
        {
          if (_context.administrators == null)
          {
              return NotFound();
          }
            return await _context.administrators.ToListAsync();
        }

        // GET: api/Administrator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrator>> GetAdministrator(int id)
        {
          if (_context.administrators == null)
          {
              return NotFound();
          }
            var administrator = await _context.administrators.FindAsync(id);

            if (administrator == null)
            {
                return NotFound();
            }

            return administrator;
        }

        // PUT: api/Administrator/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrator(int id, Administrator administrator)
        {
            if (id != administrator.idAdministrator)
            {
                return BadRequest();
            }

            _context.Entry(administrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
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

        // POST: api/Administrator
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrator>> PostAdministrator(Administrator administrator)
        {
          if (_context.administrators == null)
          {
              return Problem("Entity set 'AccountDbContext.administrators'  is null.");
          }
            _context.administrators.Add(administrator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrator", new { id = administrator.idAdministrator }, administrator);
        }

        // DELETE: api/Administrator/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            if (_context.administrators == null)
            {
                return NotFound();
            }
            var administrator = await _context.administrators.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            _context.administrators.Remove(administrator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministratorExists(int id)
        {
            return (_context.administrators?.Any(e => e.idAdministrator == id)).GetValueOrDefault();
        }
    }
}
