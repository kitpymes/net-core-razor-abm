using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database
{
    public sealed class TipoPermisoEntityTypeConfiguration : IEntityTypeConfiguration<Models.TipoPermiso>
    {
        public void Configure(EntityTypeBuilder<Models.TipoPermiso> builder)
        {
            builder.ToTable("TipoPermiso").HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Descripcion).IsRequired();
        }
    }
}
