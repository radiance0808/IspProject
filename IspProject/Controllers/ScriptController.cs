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
    public class ScriptController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public ScriptController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/Script
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Script>>> Getscripts()
        {
          if (_context.scripts == null)
          {
              return NotFound();
          }
            return await _context.scripts.ToListAsync();
        }

        // GET: api/Script/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Script>> GetScript(int id)
        {
          if (_context.scripts == null)
          {
              return NotFound();
          }
            var script = await _context.scripts.FindAsync(id);

            if (script == null)
            {
                return NotFound();
            }

            return script;
        }

        // PUT: api/Script/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScript(int id, Script script)
        {
            if (id != script.idScript)
            {
                return BadRequest();
            }

            _context.Entry(script).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptExists(id))
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

        // POST: api/Script
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Script>> PostScript(Script script)
        {
          if (_context.scripts == null)
          {
              return Problem("Entity set 'AccountDbContext.scripts'  is null.");
          }
            _context.scripts.Add(script);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScript", new { id = script.idScript }, script);
        }

        // DELETE: api/Script/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScript(int id)
        {
            if (_context.scripts == null)
            {
                return NotFound();
            }
            var script = await _context.scripts.FindAsync(id);
            if (script == null)
            {
                return NotFound();
            }

            _context.scripts.Remove(script);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScriptExists(int id)
        {
            return (_context.scripts?.Any(e => e.idScript == id)).GetValueOrDefault();
        }
    }
}
