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
    public class OtdelKadrovController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OtdelKadrovController(ApplicationContext context)
        {
            _context = context;
        }

        
        [HttpGet("OtdelsKadrov")]
        public async Task<ActionResult<IEnumerable<OtdelKadrov>>> GetOtdelsKadrov()
        {
            return await _context.OtdelsKadrov.ToListAsync();
        }

        
        [HttpGet("OtdelsKadrov/{id}")]
        public async Task<ActionResult<OtdelKadrov>> GetOtdelKadrov(int id)
        {
            var otdelKadrov = await _context.OtdelsKadrov.FindAsync(id);

            if (otdelKadrov == null)
            {
                return NotFound();
            }

            return otdelKadrov;
        }

        
        [HttpPost("OtdelsKadrov")]
        public async Task<ActionResult<OtdelKadrov>> PostOtdelKadrov(OtdelKadrov otdelKadrov)
        {
            _context.OtdelsKadrov.Add(otdelKadrov);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOtdelKadrov), new { id = otdelKadrov.Id }, otdelKadrov);
        }

        
        [HttpPut("OtdelsKadrov/{id}")]
        public async Task<IActionResult> PutOtdelKadrov(int id, OtdelKadrov otdelKadrov)
        {
            if (id != otdelKadrov.Id)
            {
                return BadRequest();
            }

            _context.Entry(otdelKadrov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtdelKadrovExists(id))
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

        
        [HttpDelete("OtdelsKadrov/{id}")]
        public async Task<IActionResult> DeleteOtdelKadrov(int id)
        {
            var otdelKadrov = await _context.OtdelsKadrov.FindAsync(id);
            if
            (otdelKadrov == null)
            {
                return NotFound();
            }

            _context.OtdelsKadrov.Remove(otdelKadrov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OtdelKadrovExists(int id)
        {
            return _context.OtdelsKadrov.Any(e => e.Id == id);
        }
    }
}
