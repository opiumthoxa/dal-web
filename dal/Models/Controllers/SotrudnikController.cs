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
    public class SotrudnikController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SotrudnikController(ApplicationContext context)
        {
            _context = context;
        }

        
        [HttpGet("Sotrudniks")]
        public async Task<ActionResult<IEnumerable<Sotrudnik>>> GetSotrudniks()
        {
            return await _context.Sotrudniks.ToListAsync();
        }

        
        [HttpGet("Sotrudniks/{id}")]
        public async Task<ActionResult<Sotrudnik>> GetSotrudnik(int id)
        {
            var sotrudnik = await _context.Sotrudniks.FindAsync(id);

            if (sotrudnik == null)
            {
                return NotFound();
            }

            return sotrudnik;
        }

        
        [HttpPost("Sotrudniks")]
        public async Task<ActionResult<Sotrudnik>> PostSotrudnik(Sotrudnik sotrudnik)
        {
            _context.Sotrudniks.Add(sotrudnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSotrudnik), new { id = sotrudnik.Id }, sotrudnik);
        }

        
        [HttpPut("Sotrudniks/{id}")]
        public async Task<IActionResult> PutSotrudnik(int id, Sotrudnik sotrudnik)
        {
            if (id != sotrudnik.Id)
            {
                return BadRequest();
            }

            _context.Entry(sotrudnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SotrudnikExists(id))
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

        
        [HttpDelete("Sotrudniks/{id}")]
        public async Task<IActionResult> DeleteSotrudnik(int id)
        {
            var sotrudnik = await _context.Sotrudniks.FindAsync(id);
            if
            (sotrudnik == null)
            {
                return NotFound();
            }

            _context.Sotrudniks.Remove(sotrudnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SotrudnikExists(int id)
        {
            return _context.Sotrudniks.Any(e => e.Id == id);
        }
    }
}
