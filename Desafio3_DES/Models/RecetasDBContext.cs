using Desafio3_DES.Models.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Desafio3_DES.Models
{
    public class RecetasDBContext: DbContext
    {
        public RecetasDBContext(DbContextOptions<RecetasDBContext> options) : base(options)
        { }

        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<PasosPreparacion> PasosPreparacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación uno a muchos entre Receta e Ingrediente
            modelBuilder.Entity<Ingrediente>()
                .HasOne(i => i.Receta)
                .WithMany(r => r.Ingredientes)
                .HasForeignKey(i => i.RecetaId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configuración de la relación uno a muchos entre Receta y PasosPreparacion
            modelBuilder.Entity<PasosPreparacion>()
                .HasOne(p => p.Receta)
                .WithMany(r => r.PasosPreparacion)
                .HasForeignKey(p => p.RecetaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new RecetaSeeds());
            modelBuilder.ApplyConfiguration(new IngredienteSeeds());
            modelBuilder.ApplyConfiguration(new PasosPreparacionSeeds());
        }
    }
}
