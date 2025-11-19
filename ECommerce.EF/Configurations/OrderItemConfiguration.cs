using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);
            builder.Property(oi => oi.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever(); // ULID is generated in the entity

            builder.Property(oi => oi.OrderId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(oi => oi.ProductId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(oi => oi.VariantId)
                .HasMaxLength(26); // ULID length

            builder.Property(oi => oi.Quantity)
                .IsRequired();

            builder.Property(oi => oi.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Subtotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Tax)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.CreatedAt)
                .IsRequired();

            builder.Property(oi => oi.UpdatedAt)
                .IsRequired();

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Variant)
                .WithMany()
                .HasForeignKey(oi => oi.VariantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
