using AutoMapper;
using DL___Web_Api.Data;
using DL___Web_Api.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SH.Data.ModelVM.Authentication;

namespace DL___Web_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ComcoMContext _context;
        private readonly IMapper _mapper;

        public SessionController(ComcoMContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionVM>>> GetSession()
        {
            var session = await _context.Sessions.ToListAsync();
            var sessionVModel = _mapper.Map<IEnumerable<SessionVM>>(session);
            return Ok(sessionVModel);
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionVM>> GetSessionByID(Guid id)
        {

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
        public async Task<IActionResult> PutSession(Guid id, Session logSession)
        {
            if (id != logSession.ID)
            {
                return BadRequest();
            }

            _context.Entry(logSession).State = EntityState.Modified;

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

        

        [HttpPost]
        public async Task<ActionResult<Session>> PostUser([FromBody] Session session)
        {

            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessionByID", new { id = session.ID }, session);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(Guid id)
        {
            var logSession = await _context.Sessions.FindAsync(id);
            if (logSession == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(logSession);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{logReqVM}")]
        public async Task<ActionResult> VerifySession([FromBody] LoginRequestVM logReqVM)
        {
            try
            {
                var a = await _context.Sessions.FirstOrDefaultAsync(e => e.UserName == logReqVM.Username && e.TokenID == logReqVM.Token);
                if (a == null)
                {
                    return Unauthorized();
                }

                if (a.ExpiryDate.Date > DateTime.Now)
                {
                    await DeleteSession(a.ID);
                    return Unauthorized();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                throw ;
            }
            
        }

        private bool SessionExists(Guid id)
        {
            return (_context.Sessions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

}

