using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Uvolnenie_PSJController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Uvolnenie_PSJController(ApplicationContext context)
        {
            _context = context;
        }

       
        [HttpGet("Uvolnenies_PSJ")]
        public async Task<ActionResult<IEnumerable<Uvolnenie_PSJ>>> GetUvolnenies_PSJ()
        {
            return await _context.Uvolnenies_PSJ.ToListAsync();
        }

        
        [HttpGet("Uvolnenies_PSJ/{id}")]
        public async Task<ActionResult<Uvolnenie_PSJ>> GetUvolnenie_PSJ(int id)
        {
            var uvolnenie_PSJ = await _context.Uvolnenies_PSJ.FindAsync(id);

            if (uvolnenie_PSJ == null)
            {
                return NotFound();
            }

            return uvolnenie_PSJ;
        }

       
        [HttpPost("Uvolnenies_PSJ")]
        public async Task<ActionResult<Uvolnenie_PSJ>> PostUvolnenie_PSJ(Uvolnenie_PSJ uvolnenie_PSJ)
        {
            _context.Uvolnenies_PSJ.Add(uvolnenie_PSJ);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUvolnenie_PSJ), new { id = uvolnenie_PSJ.Id }, uvolnenie_PSJ);
        }

        
        [HttpPut("Uvolnenies_PSJ/{id}")]
        public async Task<IActionResult> PutUvolnenie_PSJ(int id, Uvolnenie_PSJ uvolnenie_PSJ)
        {
            if (id != uvolnenie_PSJ.Id)
            {
                return BadRequest();
            }

            _context.Entry(uvolnenie_PSJ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Uvolnenie_PSJExists(id))
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

       
        [HttpDelete("Uvolnenies_PSJ/{id}")]
        public async Task<IActionResult> DeleteUvolnenie_PSJ(int id)
        {
            var uvolnenie_PSJ = await _context.Uvolnenies_PSJ.FindAsync(id);
            if
            (uvolnenie_PSJ == null)
            {
                return NotFound();
            }

            _context.Uvolnenies_PSJ.Remove(uvolnenie_PSJ);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Uvolnenie_PSJExists(int id)
        {
            return _context.Uvolnenies_PSJ.Any(e => e.Id == id);
        }
    }
}
