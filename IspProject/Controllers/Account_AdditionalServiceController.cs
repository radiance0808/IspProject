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
    public class Account_AdditionalServiceController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public Account_AdditionalServiceController(AccountDbContext context)
        {
            _context = context;
        }

        // GET: api/Account_AdditionalService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account_AdditionalService>>> Getaccount_AdditionalServices()
        {
          if (_context.account_AdditionalServices == null)
          {
              return NotFound();
          }
            return await _context.account_AdditionalServices.ToListAsync();
        }

        // GET: api/Account_AdditionalService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account_AdditionalService>> GetAccount_AdditionalService(int id)
        {
          if (_context.account_AdditionalServices == null)
          {
              return NotFound();
          }
            var account_AdditionalService = await _context.account_AdditionalServices.FindAsync(id);

            if (account_AdditionalService == null)
            {
                return NotFound();
            }

            return account_AdditionalService;
        }

        // PUT: api/Account_AdditionalService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount_AdditionalService(int id, Account_AdditionalService account_AdditionalService)
        {
            if (id != account_AdditionalService.idAccount)
            {
                return BadRequest();
            }

            _context.Entry(account_AdditionalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Account_AdditionalServiceExists(id))
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

        // POST: api/Account_AdditionalService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account_AdditionalService>> PostAccount_AdditionalService(Account_AdditionalService account_AdditionalService)
        {
          if (_context.account_AdditionalServices == null)
          {
              return Problem("Entity set 'AccountDbContext.account_AdditionalServices'  is null.");
          }
            _context.account_AdditionalServices.Add(account_AdditionalService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Account_AdditionalServiceExists(account_AdditionalService.idAccount))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccount_AdditionalService", new { id = account_AdditionalService.idAccount }, account_AdditionalService);
        }

        // DELETE: api/Account_AdditionalService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount_AdditionalService(int id)
        {
            if (_context.account_AdditionalServices == null)
            {
                return NotFound();
            }
            var account_AdditionalService = await _context.account_AdditionalServices.FindAsync(id);
            if (account_AdditionalService == null)
            {
                return NotFound();
            }

            _context.account_AdditionalServices.Remove(account_AdditionalService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Account_AdditionalServiceExists(int id)
        {
            return (_context.account_AdditionalServices?.Any(e => e.idAccount == id)).GetValueOrDefault();
        }
    }
}
