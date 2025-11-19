using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever(); // ULID is generated in the entity

            builder.Property(c => c.ApplicationUserId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(c => c.Gender)
                .HasMaxLength(20);

            builder.Property(c => c.Bio)
                .HasMaxLength(500);

            builder.Property(c => c.ProfilePictureUrl)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Language)
                .HasMaxLength(10);

            builder.HasMany(c => c.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Reviews)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.WishlistItems)
                .WithOne(w => w.Customer)
                .HasForeignKey(w => w.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
