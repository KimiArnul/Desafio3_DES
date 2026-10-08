using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio3_DES.Models;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PasosPreparacionsController : ControllerBase
{
    private readonly RecetasDBContext _context;
    public PasosPreparacionsController(RecetasDBContext context)
    {
        _context = context;
    }

    // GET: api/PasosPreparacion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PasosPreparacion>>> GetPasosPreparacion()
    {
        return await _context.PasosPreparacion.ToListAsync();
    }

    // GET: api/PasosPreparacion/5
    [HttpGet("{idpaso}")]
    public async Task<ActionResult<PasosPreparacion>> GetPasosPreparacion(int idpaso)
    {
        var pasospreparacion = await _context.PasosPreparacion.FindAsync(idpaso);

        if (pasospreparacion == null)
        {
            return NotFound();
        }

        return pasospreparacion;
    }

    // PUT: api/PasosPreparacion/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idpaso}")]
    [Authorize(Policy = "SoloAdministrador")]
    public async Task<IActionResult> PutPasosPreparacion(int? idpaso, PasosPreparacion pasospreparacion)
    {
        if (idpaso != pasospreparacion.IdPaso)
        {
            return BadRequest();
        }

        _context.Entry(pasospreparacion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PasosPreparacionExists(idpaso))
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

    // POST: api/PasosPreparacion
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Policy = "SoloAdministrador")]
    public async Task<ActionResult<PasosPreparacion>> PostPasosPreparacion(PasosPreparacion pasospreparacion)
    {
        _context.PasosPreparacion.Add(pasospreparacion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPasosPreparacion", new { idpaso = pasospreparacion.IdPaso }, pasospreparacion);
    }

    // DELETE: api/PasosPreparacion/5
    [HttpDelete("{idpaso}")]
    [Authorize(Policy = "SoloAdministrador")]
    public async Task<IActionResult> DeletePasosPreparacion(int? idpaso)
    {
        var pasospreparacion = await _context.PasosPreparacion.FindAsync(idpaso);
        if (pasospreparacion == null)
        {
            return NotFound();
        }

        _context.PasosPreparacion.Remove(pasospreparacion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PasosPreparacionExists(int? idpaso)
    {
        return _context.PasosPreparacion.Any(e => e.IdPaso == idpaso);
    }
}
