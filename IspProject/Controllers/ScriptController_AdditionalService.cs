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
    public class ScriptController_AdditionalService : ControllerBase
    {
        private readonly AccountDbContext _context;

        public ScriptController_AdditionalService(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/ScriptController_AdditionalService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Script_AdditionalService>>> Getscript_additionalServices()
        {
          if (_context.script_additionalServices == null)
          {
              return NotFound();
          }
            return await _context.script_additionalServices.ToListAsync();
        }

        // GET: api/ScriptController_AdditionalService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Script_AdditionalService>> GetScript_AdditionalService(int id)
        {
          if (_context.script_additionalServices == null)
          {
              return NotFound();
          }
            var script_AdditionalService = await _context.script_additionalServices.FindAsync(id);

            if (script_AdditionalService == null)
            {
                return NotFound();
            }

            return script_AdditionalService;
        }

        // PUT: api/ScriptController_AdditionalService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScript_AdditionalService(int id, Script_AdditionalService script_AdditionalService)
        {
            if (id != script_AdditionalService.idScript)
            {
                return BadRequest();
            }

            _context.Entry(script_AdditionalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Script_AdditionalServiceExists(id))
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

        // POST: api/ScriptController_AdditionalService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Script_AdditionalService>> PostScript_AdditionalService(Script_AdditionalService script_AdditionalService)
        {
          if (_context.script_additionalServices == null)
          {
              return Problem("Entity set 'AccountDbContext.script_additionalServices'  is null.");
          }
            _context.script_additionalServices.Add(script_AdditionalService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Script_AdditionalServiceExists(script_AdditionalService.idScript))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScript_AdditionalService", new { id = script_AdditionalService.idScript }, script_AdditionalService);
        }

        // DELETE: api/ScriptController_AdditionalService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScript_AdditionalService(int id)
        {
            if (_context.script_additionalServices == null)
            {
                return NotFound();
            }
            var script_AdditionalService = await _context.script_additionalServices.FindAsync(id);
            if (script_AdditionalService == null)
            {
                return NotFound();
            }

            _context.script_additionalServices.Remove(script_AdditionalService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Script_AdditionalServiceExists(int id)
        {
            return (_context.script_additionalServices?.Any(e => e.idScript == id)).GetValueOrDefault();
        }
    }
}
