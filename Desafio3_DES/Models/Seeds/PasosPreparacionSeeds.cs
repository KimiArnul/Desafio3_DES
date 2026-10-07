using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio3_DES.Models.Seeds
{
    public class PasosPreparacionSeeds : IEntityTypeConfiguration<PasosPreparacion>
    {
        public void Configure(EntityTypeBuilder<PasosPreparacion> builder)
        {
            builder.HasData(
                new PasosPreparacion
                {
                    IdPaso = -1,
                    DescripcionPaso = "Lavar la lechuga y cortarla en trozos.",
                    OrdenPaso = 1,
                    RecetaId = -1
                },
                new PasosPreparacion
                {
                    IdPaso = -2,
                    DescripcionPaso = "Asar el pollo a la parrilla y cortarlo en tiras",
                    OrdenPaso = 2,
                    RecetaId = -1
                },
                new PasosPreparacion
                {
                    IdPaso = -3,
                    DescripcionPaso = "Mezclar la lechuga, el pollo y el aderezo César",
                    OrdenPaso = 3,
                    RecetaId = -1
                },
                new PasosPreparacion
                {
                    IdPaso = -4,
                    DescripcionPaso = "Cocinar la passta en agua hirviendo con sal.",
                    OrdenPaso = 1,
                    RecetaId = -2
                },
                new PasosPreparacion
                {
                    IdPaso = -5,
                    DescripcionPaso = "Mezclar el huevo, la crema y el queso parmesano.",
                    OrdenPaso = 2,
                    RecetaId = -2
                },
                new PasosPreparacion
                {
                    IdPaso = -6,
                    DescripcionPaso = "Añadir la mezcla a la pasta caliente.",
                    OrdenPaso = 3,
                    RecetaId = -2
                },
                new PasosPreparacion
                {
                    IdPaso = -7,
                    DescripcionPaso = "Cortal los tomates y hervirlos hasta que se ablanden.",
                    OrdenPaso = 1,
                    RecetaId = -3
                },
                new PasosPreparacion
                {
                    IdPaso = -8,
                    DescripcionPaso = "Licuar los tomates y agregar la albahaca.",
                    OrdenPaso = 2,
                    RecetaId = -3
                },
                new PasosPreparacion
                {
                    IdPaso = -9,
                    DescripcionPaso = "Cocinar por 10 miutos y servir caliente.",
                    OrdenPaso = 3,
                    RecetaId = -3
                }
            );
        }
    }
}
