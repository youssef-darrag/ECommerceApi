using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever();

            builder.Property(a => a.ApplicationUserId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(a => a.Position)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
