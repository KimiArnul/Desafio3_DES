using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio3_DES.Models.Seeds
{
    public class IngredienteSeeds : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.HasData(
                new Ingrediente
                {
                    IdIngrediente = -1,
                    NombreIngrediente = "Lechuga Romana",
                    Cantidad = 1,
                    UnidadMedida = "Unidad",
                    RecetaId = -1
                },
                new Ingrediente
                {
                    IdIngrediente = -2,
                    NombreIngrediente = "Pollo a la parrilla",
                    Cantidad = 200,
                    UnidadMedida = "Gramos",
                    RecetaId = -1
                },
                new Ingrediente
                {
                    IdIngrediente = -3,
                    NombreIngrediente = "Aderezo César",
                    Cantidad = 50,
                    UnidadMedida = "Mililitros",
                    RecetaId = -1
                },
                new Ingrediente
                {
                    IdIngrediente = -4,
                    NombreIngrediente = "pasta Espagueti",
                    Cantidad = 250,
                    UnidadMedida = "Gramos",
                    RecetaId = -2
                },
                new Ingrediente
                {
                    IdIngrediente = -5,
                    NombreIngrediente = "Crema de Leche",
                    Cantidad = 100,
                    UnidadMedida = "Mililitros",
                    RecetaId = -2
                },
                new Ingrediente
                {
                    IdIngrediente = -6,
                    NombreIngrediente = "Huevo",
                    Cantidad = 1,
                    UnidadMedida = "Unidad",
                    RecetaId = -2
                },
                new Ingrediente
                {
                    IdIngrediente = -7,
                    NombreIngrediente = "Queso Parmesano",
                    Cantidad = 50,
                    UnidadMedida = "Gramos",
                    RecetaId = -2
                },
                new Ingrediente
                {
                    IdIngrediente = -8,
                    NombreIngrediente = "Tomates frescos",
                    Cantidad = 500,
                    UnidadMedida = "Gramos",
                    RecetaId = -3
                },
                new Ingrediente
                {
                    IdIngrediente = -9,
                    NombreIngrediente = "Albahaca",
                    Cantidad = 5,
                    UnidadMedida = "Hojas",
                    RecetaId = -3
                }
            );
        }
    }
}
