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
    public class Uvolnenie_RukovodstvomController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Uvolnenie_RukovodstvomController(ApplicationContext context)
        {
            _context = context;
        }

        
        [HttpGet("Uvolnenies_Rukovodstvom")]
        public async Task<ActionResult<IEnumerable<Uvolnenie_Rukovodstvom>>> GetUvolnenies_Rukovodstvom()
        {
            return await _context.Uvolnenies_Rukovodstvom.ToListAsync();
        }

       
        [HttpGet("Uvolnenies_Rukovodstvom/{id}")]
        public async Task<ActionResult<Uvolnenie_Rukovodstvom>> GetUvolnenie_Rukovodstvom(int id)
        {
            var uvolnenie_Rukovodstvom = await _context.Uvolnenies_Rukovodstvom.FindAsync(id);

            if (uvolnenie_Rukovodstvom == null)
            {
                return NotFound();
            }

            return uvolnenie_Rukovodstvom;
        }

        
        [HttpPost("Uvolnenies_Rukovodstvom")]
        public async Task<ActionResult<Uvolnenie_Rukovodstvom>> PostUvolnenie_Rukovodstvom(Uvolnenie_Rukovodstvom uvolnenie_Rukovodstvom)
        {
            _context.Uvolnenies_Rukovodstvom.Add(uvolnenie_Rukovodstvom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUvolnenie_Rukovodstvom), new { id = uvolnenie_Rukovodstvom.Id }, uvolnenie_Rukovodstvom);
        }

        
        [HttpPut("Uvolnenies_Rukovodstvom/{id}")]
        public async Task<IActionResult> PutUvolnenie_Rukovodstvom(int id, Uvolnenie_Rukovodstvom uvolnenie_Rukovodstvom)
        {
            if (id != uvolnenie_Rukovodstvom.Id)
            {
                return BadRequest();
            }

            _context.Entry(uvolnenie_Rukovodstvom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Uvolnenie_RukovodstvomExists(id))
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

        
        [HttpDelete("Uvolnenies_Rukovodstvom/{id}")]
        public async Task<IActionResult> DeleteUvolnenie_Rukovodstvom(int id)
        {
            var uvolnenie_Rukovodstvom = await _context.Uvolnenies_Rukovodstvom.FindAsync(id);
            if
            (uvolnenie_Rukovodstvom == null)
            {
                return NotFound();
            }

            _context.Uvolnenies_Rukovodstvom.Remove(uvolnenie_Rukovodstvom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Uvolnenie_RukovodstvomExists(int id)
        {
            return _context.Uvolnenies_Rukovodstvom.Any(e => e.Id == id);
        }
    }
}
