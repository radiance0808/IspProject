using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IspProject.Models;
using IspProject.DTOs;
using AutoMapper;

namespace IspProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AccountDbContext _context;
        private readonly IMapper _mapper;

        public UserController(AccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Getusers()
        {
          if (_context.users == null)
          {
              return NotFound();
          }
            var users = await _context.users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
            
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.users == null)
          {
              return NotFound();
          }
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserCreationDTO userCreationDTO)
        {
            var user = await _context.users.FindAsync(id);

            if (id != user.idUser)
            {
                return BadRequest();
            }

            if (user == null)
            {
                return NotFound();
            }

            user = _mapper.Map(userCreationDTO, user);

            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreationDTO userCreationDTO)
        {
          if (_context.users == null)
          {
              return Problem("Entity set 'AccountDbContext.users'  is null.");
          }
          var user = _mapper.Map<User>(userCreationDTO);
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.idUser }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.users == null)
            {
                return NotFound();
            }
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.users?.Any(e => e.idUser == id)).GetValueOrDefault();
        }
    }
}
