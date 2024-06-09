
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DL___Web_Api.Data;
using DL___Web_Api.Model.Models;

using DL___Web_Api.Filters;
using DL___Web_Api.Repository;

namespace DL___Web_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TokenAuthenticationFilter]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_userRepository.GetUsers == null)
            {
                return NotFound();
            }
            return await _userRepository.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            if (_userRepository.GetUser(id) == null)
            {
                return NotFound();
            }
            var user = await _userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            try
            {
                await _userRepository.PutUser (id, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_userRepository.PutUser(id, user) == null)
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_userRepository == null)
            {
                return Problem("Entity set 'ComcoMContext.Users'  is null.");
            }

            await _userRepository.PostUser(user);
            ///??????
            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (_userRepository.DeleteUser(id) == null)
            {
                return NotFound();
            }
            await _userRepository.DeleteUser(id);

            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return _userRepository.UserExists(id);
        }
    }
}
