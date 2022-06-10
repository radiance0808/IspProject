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
    public class PackageController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public PackageController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/Package
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> Getpackages()
        {
          if (_context.packages == null)
          {
              return NotFound();
          }
            return await _context.packages.ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
          if (_context.packages == null)
          {
              return NotFound();
          }
            var package = await _context.packages.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Package/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            if (id != package.idPackage)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Package
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
          if (_context.packages == null)
          {
              return Problem("Entity set 'AccountDbContext.packages'  is null.");
          }
            _context.packages.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.idPackage }, package);
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            if (_context.packages == null)
            {
                return NotFound();
            }
            var package = await _context.packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.packages.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageExists(int id)
        {
            return (_context.packages?.Any(e => e.idPackage == id)).GetValueOrDefault();
        }
    }
}
