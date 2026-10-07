using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio3_DES.Models.Seeds
{
    public class RecetaSeeds: IEntityTypeConfiguration<Receta>
    {
        public void Configure(EntityTypeBuilder<Receta> builder)
        {
            builder.HasData(
                new Receta
                {
                    IdReceta = -1,
                    NombreReceta = "Ensalada César",
                    Descripcion = "Ensalada clásica con pollo, lechuga y aderezo César.",
                    TiempoPreparacion = new TimeOnly(0, 20, 0) // 0 horas y  minutos
                },
                new Receta
                {
                    IdReceta = -2,
                    NombreReceta = "Pasta Carbonara",
                    Descripcion = "Pasta con salsa de crema, huevo y queso parmesano.",
                    TiempoPreparacion = new TimeOnly(0, 30, 0) // 0 horas y 30 minutos
                },
                new Receta
                {
                    IdReceta = -3,
                    NombreReceta = "Sopa de Tomate",
                    Descripcion = "Sopa ligera de tomate con albahaca.",
                    TiempoPreparacion = new TimeOnly(0, 40, 0) // 0 horas y 40 minutos
                }
            );
        }
    }
}
