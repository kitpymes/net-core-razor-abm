using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database
{
    public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<Models.User>
    {
        public void Configure(EntityTypeBuilder<Models.User> builder)
        {
            builder.HasKey(x => x.Id );

            builder.Property(x => x.Id ).ValueGeneratedOnAdd();

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.Password).IsRequired();
        }
    }
}
