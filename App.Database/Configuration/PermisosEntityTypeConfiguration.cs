using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database
{
    public sealed class PermisosEntityTypeConfiguration : IEntityTypeConfiguration<Models.Permisos>
    {
        public void Configure(EntityTypeBuilder<Models.Permisos> builder)
        {
            builder.ToTable("Permisos").HasKey(x => x.Id );

            builder.Property(x => x.Id ).ValueGeneratedOnAdd();

            builder.Property(x => x.NombreEmpleado).IsRequired();

            builder.Property(x => x.ApellidoEmpleado).IsRequired();

            builder.Property(x => x.FechaPermiso).IsRequired();

            builder.Property(x => x.TipoPermisoId).IsRequired();
        }
    }
}
