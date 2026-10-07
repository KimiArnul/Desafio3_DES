using Desafio3_DES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio3_DES.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecetasController : ControllerBase
    {
        private readonly RecetasDBContext _context;

        public RecetasController(RecetasDBContext context)
        {
            _context = context;
        }

        // GET: api/Recetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetas()
        {
            return await _context.Recetas
                .Include(r => r.Ingredientes)
                .Include(r => r.PasosPreparacion)
                .ToListAsync();
        }

        // GET: api/Recetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receta>> GetReceta(int id)
        {
            var receta = await _context.Recetas
                .Include(r => r.Ingredientes)
                .Include(r => r.PasosPreparacion)
                .FirstOrDefaultAsync(r => r.IdReceta == id);

            if (receta == null)
            {
                return NotFound();
            }

            return receta;
        }

        // POST: api/Recetas
        [HttpPost]
        public async Task<ActionResult<Receta>> PostReceta(Receta receta)
        {
            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceta), new { id = receta.IdReceta }, receta);
        }

        // PUT: api/Recetas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta(int id, Receta receta)
        {
            if (id != receta.IdReceta)
            {
                return BadRequest();
            }

            _context.Entry(receta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
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

        // DELETE: api/Recetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }

            _context.Recetas.Remove(receta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecetaExists(int id)
        {
            return _context.Recetas.Any(e => e.IdReceta == id);
        }
    }
}
