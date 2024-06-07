using DL___Web_Api.Data;
using DL___Web_Api.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using SH.Data.ModelVM.Authentication;

namespace DL___Web_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ComcoMContext _context;

        public SessionController(ComcoMContext context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSession()
        {
            if (_context.Sessions == null)
            {

                return NotFound();
            }
            return await _context.Sessions.ToListAsync();
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSessionByID(Guid id)
        {
            if (_context.Sessions == null)
            {
                return NotFound();
            }
            var logsession = await _context.Sessions.FindAsync(id);

            if (logsession == null)
            {
                return NotFound();
            }

            return logsession;
        }

        // PUT: api/Sessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(Guid id, Session logsession)
        {
            if (id != logsession.ID)
            {
                return BadRequest();
            }

            _context.Entry(logsession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // POST: api/Sessions
        //[HttpPost]
        //public async Task<ActionResult<Session>> PostSession(Session logsession)
        //{
        //    if (_context.Sessions == null)
        //    {
        //        return Problem("Entity set 'ComcoMContext.Users'  is null.");
        //    }
        //    _context.Sessions.Add(logsession);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetToken", new { id = logsession.ID }, logsession);
        //}

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(Guid id)
        {
            if (_context.Sessions == null)
            {
                return NotFound();
            }
            var logsession = await _context.Sessions.FindAsync(id);
            if (logsession == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(logsession);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> VerifySession( [FromBody] VerifySessionVM verifys)
        {
            if (_context.Sessions == null)
            {
                return NotFound();
            }
            var a = await _context.Sessions.FirstOrDefaultAsync(e => e.UserName == verifys.UserName && e.TokenID == verifys.Token);
            if ( a == null )
            {
                return NoContent();
            }
            else
            {
                if (a.ExpiryDate.Date > DateTime.Now)
                {
                    DeleteSession(a.ID);
                    return NoContent();
                }
                else return Ok(true);
               
            }
        }

        private bool SessionExists(Guid id)
        {
            return (_context.Sessions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

}

