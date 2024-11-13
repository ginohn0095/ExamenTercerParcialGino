using ExamenTercerParcialGino.Data;
using ExamenTercerParcialGino.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenTercerParcialGino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RopaController : Controller
    {
        private readonly Ropacontext _context;

        public RopaController(Ropacontext context)
        {
            _context = context;
        }

        // GET: api/Ropa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ropa>>> GetRopa()
        {
            return await _context.Ropa.ToListAsync(); // Asumiendo que la tabla se llama "Ropa"
        }

        // GET: api/Ropa/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ropa>> GetRopa(int id)
        {
            var ropa = await _context.Ropa.FindAsync(id);
            if (ropa == null)
            {
                return NotFound();
            }
            return ropa;
        }

        // POST: api/Ropa
        [HttpPost]
        public async Task<ActionResult> PostRopa(Ropa ropa)
        {
            _context.Ropa.Add(ropa);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRopa", new { id = ropa.id }, ropa);
        }

        // PUT: api/Ropa/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRopa(int id, Ropa ropa)
        {
            if (id != ropa.id)
            {
                return BadRequest();
            }

            _context.Entry(ropa).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ropa.Any(e => e.id == id))
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

        // DELETE: api/Ropa/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRopa(int id)
        {
            var ropa = await _context.Ropa.FindAsync(id);
            if (ropa == null)
            {
                return NotFound();
            }
            _context.Ropa.Remove(ropa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
