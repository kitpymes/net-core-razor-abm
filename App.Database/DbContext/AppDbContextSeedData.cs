using Microsoft.EntityFrameworkCore;
using System;

namespace App.Database
{
    public static class AppDbContextSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Models.User>().HasData(
            //    new { Id = 1,  Email = "admin@gmail.com", Password = "" },
            //    new { Id = 2, Email = "user@gmail.com", Password = "" }
            //);

            modelBuilder.Entity<Models.PermissionType>().HasData(
                new { Id = 1, Descripcion = "Enfermedad" },
                new { Id = 2, Descripcion = "Licencia" },
                new { Id = 3, Descripcion = "Trámites" }
            );

            modelBuilder.Entity<Models.Permission>().HasData(
                new { Id = 1, Name = "Claudia", Surname = "Garcia", Date= DateTime.Now, PermissionTypeId = 1 },
                new { Id = 2, Name = "Pedro", Surname = "Perez", Date = DateTime.Now, PermissionTypeId = 1 },
                new { Id = 3, Name = "Juan", Surname = "Otelo", Date = DateTime.Now, PermissionTypeId = 3 }
            );
        }
    }
}
