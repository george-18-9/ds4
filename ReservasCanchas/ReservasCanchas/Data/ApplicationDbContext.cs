using Microsoft.EntityFrameworkCore;
using ReservasCanchas.Models;
using System.Collections.Generic;

namespace ReservasCanchas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cancha> Canchas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
