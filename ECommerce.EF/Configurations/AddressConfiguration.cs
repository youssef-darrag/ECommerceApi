using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever();

            builder.Property(a => a.CustomerId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(a => a.AddressLine)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Phone)
                .HasMaxLength(20);

            builder.Property(a => a.CreatedAt)
                .IsRequired();

            builder.Property(a => a.UpdatedAt)
                .IsRequired();
        }
    }
}
