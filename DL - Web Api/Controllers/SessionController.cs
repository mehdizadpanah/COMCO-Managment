using AutoMapper;
using DL___Web_Api.Data;
using DL___Web_Api.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Common;
using SH.Data.ModelVM.Authentication;

namespace DL___Web_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ComcoMContext _context;
        private readonly IMapper _mapper;

        public SessionController(ComcoMContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionVM>>> GetSession()
        {
            if (_context.Sessions == null)
            {

                return NotFound();
            }
            var session = await _context.Sessions.ToListAsync();
            var sessionVModel = _mapper.Map<IEnumerable<SessionVM>>(session);
            return Ok(sessionVModel);
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionVM>> GetSessionByID(Guid id)
        {
            if (_context.Sessions == null)
            {
                return NotFound();
            }
            var session = await _context.Sessions.FindAsync(id);
            var sessionVModel = _mapper.Map<SessionVM>(session);    

            if (sessionVModel == null)
            {
                return NotFound();
            }

            return (sessionVModel);
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
        public async Task<ActionResult> VerifySession( [FromBody] LoginRequestVM verifys)
        {
            if (_context.Sessions == null)
            {
                return Unauthorized();
            }
            var a = await _context.Sessions.FirstOrDefaultAsync(e => e.UserName == verifys.Username && e.TokenID == verifys.Token);
            if ( a == null )
            {
                return Unauthorized();
            }
            else
            {
                if (a.ExpiryDate.Date > DateTime.Now)
                {
                    DeleteSession(a.ID);
                    return Unauthorized();
                }
                else return Ok();
               
            }
        }

        private bool SessionExists(Guid id)
        {
            return (_context.Sessions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

}

