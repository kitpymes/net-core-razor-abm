using Microsoft.EntityFrameworkCore;

namespace Permisos.Database
{
    public class PermisosContext : DbContext
    {
        public DbSet<Models.Permisos> Permisos { get; set; }
        public DbSet<Models.TipoPermiso> TipoPermiso { get; set; }

        public PermisosContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
