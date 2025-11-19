using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever(); // ULID is generated in the entity

            builder.Property(w => w.CustomerId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(w => w.ProductId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(w => w.CreatedAt)
                .IsRequired();

            builder.HasIndex(w => new { w.CustomerId, w.ProductId })
                .IsUnique();
        }
    }
}
