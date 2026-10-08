using Desafio3_DES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Desafio3_DES.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
        [Authorize(Policy = "SoloAdministrador")]
        public async Task<ActionResult<Receta>> PostReceta(Receta receta)
        {
            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceta), new { id = receta.IdReceta }, receta);
        }

        // PUT: api/Recetas/5
        [HttpPut("{id}")]
        [Authorize(Policy = "SoloAdministrador")]
        public async Task<IActionResult> PutReceta(int id, Receta receta)
        {
            if (id != receta.IdReceta)
            {
                return BadRequest();
            }

            // Cargamos la receta existente con sus relaciones para que EF pueda
            // detectar altas, modificaciones y eliminaciones en las colecciones.
            var recetaExistente = await _context.Recetas
                .Include(r => r.Ingredientes)
                .Include(r => r.PasosPreparacion)
                .FirstOrDefaultAsync(r => r.IdReceta == id);

            if (recetaExistente == null)
            {
                return NotFound();
            }

            recetaExistente.NombreReceta = receta.NombreReceta;
            recetaExistente.Descripcion = receta.Descripcion;
            recetaExistente.TiempoPreparacion = receta.TiempoPreparacion;

            var ingredientesRecibidos = receta.Ingredientes ?? [];
            var ingredientesExistentes = recetaExistente.Ingredientes.ToList();
            var idsIngredientesRecibidos = ingredientesRecibidos
                .Where(i => i.IdIngrediente != 0)
                .Select(i => i.IdIngrediente)
                .ToHashSet();

            foreach (var ingrediente in ingredientesRecibidos)
            {
                if (ingrediente.IdIngrediente == 0)
                {
                    recetaExistente.Ingredientes.Add(new Ingrediente
                    {
                        NombreIngrediente = ingrediente.NombreIngrediente,
                        Cantidad = ingrediente.Cantidad,
                        UnidadMedida = ingrediente.UnidadMedida,
                        RecetaId = id
                    });
                    continue;
                }

                var ingredienteExistente = ingredientesExistentes
                    .FirstOrDefault(i => i.IdIngrediente == ingrediente.IdIngrediente);

                if (ingredienteExistente == null)
                {
                    return BadRequest($"El ingrediente {ingrediente.IdIngrediente} no pertenece a la receta {id}.");
                }

                ingredienteExistente.NombreIngrediente = ingrediente.NombreIngrediente;
                ingredienteExistente.Cantidad = ingrediente.Cantidad;
                ingredienteExistente.UnidadMedida = ingrediente.UnidadMedida;
            }

            foreach (var ingredienteExistente in ingredientesExistentes
                .Where(i => !idsIngredientesRecibidos.Contains(i.IdIngrediente)))
            {
                _context.Ingredientes.Remove(ingredienteExistente);
            }

            var pasosRecibidos = receta.PasosPreparacion ?? [];
            var pasosExistentes = recetaExistente.PasosPreparacion.ToList();
            var idsPasosRecibidos = pasosRecibidos
                .Where(p => p.IdPaso != 0)
                .Select(p => p.IdPaso)
                .ToHashSet();

            foreach (var paso in pasosRecibidos)
            {
                if (paso.IdPaso == 0)
                {
                    recetaExistente.PasosPreparacion.Add(new PasosPreparacion
                    {
                        DescripcionPaso = paso.DescripcionPaso,
                        OrdenPaso = paso.OrdenPaso,
                        RecetaId = id
                    });
                    continue;
                }

                var pasoExistente = pasosExistentes
                    .FirstOrDefault(p => p.IdPaso == paso.IdPaso);

                if (pasoExistente == null)
                {
                    return BadRequest($"El paso {paso.IdPaso} no pertenece a la receta {id}.");
                }

                pasoExistente.DescripcionPaso = paso.DescripcionPaso;
                pasoExistente.OrdenPaso = paso.OrdenPaso;
            }

            foreach (var pasoExistente in pasosExistentes
                .Where(p => !idsPasosRecibidos.Contains(p.IdPaso)))
            {
                _context.PasosPreparacion.Remove(pasoExistente);
            }

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
        [Authorize(Policy = "SoloAdministrador")]
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
