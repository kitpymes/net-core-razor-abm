using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Models.Permisos> Permisos { get; set; }
        public DbSet<Models.TipoPermiso> TipoPermiso { get; set; }

        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}
