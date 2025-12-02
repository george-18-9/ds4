using Microsoft.EntityFrameworkCore;
using BufeteGW.Models; // 👈 AGREGA ESTA LÍNEA

namespace BufeteGW.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tablas
        public DbSet<GW_Abogado> GW_Abogados { get; set; }
        public DbSet<GW_Cliente> GW_Clientes { get; set; }
        public DbSet<GW_Caso> GW_Casos { get; set; }
        public DbSet<GW_Documento> GW_Documentos { get; set; }
        public DbSet<GW_Evento> GW_Eventos { get; set; }
    }
}

