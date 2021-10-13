using Microsoft.EntityFrameworkCore;
using System;

namespace App.Database
{
    public static class AppDbContextSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.TipoPermiso>().HasData(
                new { Id = 1, Descripcion = "Enfermedad" },
                new { Id = 2, Descripcion = "Licencia" },
                new { Id = 3, Descripcion = "Trámites" }
            );

            modelBuilder.Entity<Models.Permisos>().HasData(
                new { Id = 1, NombreEmpleado = "Claudia", ApellidoEmpleado = "Garcia", FechaPermiso= DateTime.Now, TipoPermisoId = 1 },
                new { Id = 2, NombreEmpleado = "Pedro", ApellidoEmpleado = "Perez", FechaPermiso = DateTime.Now, TipoPermisoId = 1 },
                new { Id = 3, NombreEmpleado = "Juan", ApellidoEmpleado = "Otelo", FechaPermiso = DateTime.Now, TipoPermisoId = 3 }
            );
        }
    }
}
