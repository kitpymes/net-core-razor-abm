using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database
{
    public sealed class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Models.Permission>
    {
        public void Configure(EntityTypeBuilder<Models.Permission> builder)
        {
            builder.HasKey(x => x.Id );

            builder.Property(x => x.Id ).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Surname).IsRequired();

            builder.Property(x => x.Date).IsRequired();

            builder.Property(x => x.PermissionTypeId).IsRequired();
        }
    }
}
