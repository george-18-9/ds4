using CalculadoraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraAPI.Data
{
    public class CalculadoraContext : DbContext
    {
        public CalculadoraContext(DbContextOptions<CalculadoraContext> options) : base(options) { }

        public DbSet<Calculo> Calculos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapear la entidad Calculo a la tabla "Operaciones"
            modelBuilder.Entity<Calculo>().ToTable("Operaciones");

            base.OnModelCreating(modelBuilder);
        }
    }
}
