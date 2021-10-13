using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database
{
    public sealed class PermissionTypeEntityTypeConfiguration : IEntityTypeConfiguration<Models.PermissionType>
    {
        public void Configure(EntityTypeBuilder<Models.PermissionType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Descripcion).IsRequired();
        }
    }
}
