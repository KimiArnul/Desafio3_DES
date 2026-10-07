using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio3_DES.Models;

[Route("api/[controller]")]
[ApiController]
public class IngredientesController : ControllerBase
{
    private readonly RecetasDBContext _context;
    public IngredientesController(RecetasDBContext context)
    {
        _context = context;
    }

    // GET: api/Ingrediente
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngrediente()
    {
        return await _context.Ingredientes.ToListAsync();
    }

    // GET: api/Ingrediente/5
    [HttpGet("{idingrediente}")]
    public async Task<ActionResult<Ingrediente>> GetIngrediente(int idingrediente)
    {
        var ingrediente = await _context.Ingredientes.FindAsync(idingrediente);

        if (ingrediente == null)
        {
            return NotFound();
        }

        return ingrediente;
    }

    // PUT: api/Ingrediente/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idingrediente}")]
    public async Task<IActionResult> PutIngrediente(int? idingrediente, Ingrediente ingrediente)
    {
        if (idingrediente != ingrediente.IdIngrediente)
        {
            return BadRequest();
        }

        _context.Entry(ingrediente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IngredienteExists(idingrediente))
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

    // POST: api/Ingrediente
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Ingrediente>> PostIngrediente(Ingrediente ingrediente)
    {
        _context.Ingredientes.Add(ingrediente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetIngrediente", new { idingrediente = ingrediente.IdIngrediente }, ingrediente);
    }

    // DELETE: api/Ingrediente/5
    [HttpDelete("{idingrediente}")]
    public async Task<IActionResult> DeleteIngrediente(int? idingrediente)
    {
        var ingrediente = await _context.Ingredientes.FindAsync(idingrediente);
        if (ingrediente == null)
        {
            return NotFound();
        }

        _context.Ingredientes.Remove(ingrediente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IngredienteExists(int? idingrediente)
    {
        return _context.Ingredientes.Any(e => e.IdIngrediente == idingrediente);
    }
}
