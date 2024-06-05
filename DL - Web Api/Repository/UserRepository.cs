using DL___Web_Api.Data;
using DL___Web_Api.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DL___Web_Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ComcoMContext _context;

        public UserRepository()
        {
            _context = new ComcoMContext();
        }

        

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {

                return null;
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }
        public async Task<User> GetUserByDCUname(string dcusername)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(e => e.DcUsername == dcusername);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.ID)
            {
                return null;
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        // POST: api/Users
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return null;
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtActionResult("GetUser", new { id = user.ID }, user);
        }

        private ActionResult<User> CreatedAtActionResult(string v, object value, User user)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Users/5

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return null;
        }

        private bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        bool IUserRepository.UserExists(Guid id)
        {                               
            throw new NotImplementedException();
        }

        Task<IActionResult> IUserRepository.PostUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
