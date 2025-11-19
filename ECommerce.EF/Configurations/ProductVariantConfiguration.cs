using ECommerce.Core.Constants;
using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever(); // ULID is generated in the entity

            builder.Property(v => v.ProductId)
                .IsRequired()
                .HasMaxLength(26); // ULID length

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(v => v.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.CompareAtPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.CostPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.InventoryQuantity)
                .IsRequired();

            builder.Property(v => v.LowStockThreshold)
                .IsRequired();

            builder.Property(v => v.Weight)
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.WeightUnit)
                .HasMaxLength(20);

            builder.Property(v => v.CreatedAt)
                .IsRequired();

            builder.Property(v => v.UpdatedAt)
                .IsRequired();

            builder.HasMany(v => v.Images)
                .WithOne(i => i.Variant)
                .HasForeignKey(i => i.VariantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(LoadProductVariants());
        }

        private IEnumerable<ProductVariant> LoadProductVariants()
        {
            return new List<ProductVariant>
            {
                // كشري
                new ProductVariant
                {
                    Id = ProductVariantIds.KosharySmall,
                    ProductId = ProductIds.KosharyClassic,
                    Name = "كشري صغير",
                    Price = 25.00m,
                    CompareAtPrice = 30.00m,
                    CostPrice = 15.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 250,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.KosharyMedium,
                    ProductId = ProductIds.KosharyClassic,
                    Name = "كشري متوسط",
                    Price = 35.00m,
                    CompareAtPrice = 40.00m,
                    CostPrice = 20.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 350,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.KosharyLarge,
                    ProductId = ProductIds.KosharyClassic,
                    Name = "كشري كبير",
                    Price = 45.00m,
                    CompareAtPrice = 50.00m,
                    CostPrice = 25.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 500,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // ملوخية بالفراخ
                new ProductVariant
                {
                    Id = ProductVariantIds.MolokhiaChickenSmall,
                    ProductId = ProductIds.MolokhiaWithChicken,
                    Name = "ملوخية بالفراخ - حصة صغيرة",
                    Price = 45.00m,
                    CompareAtPrice = 50.00m,
                    CostPrice = 25.00m,
                    InventoryQuantity = 50,
                    LowStockThreshold = 10,
                    Weight = 300,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.MolokhiaChickenMedium,
                    ProductId = ProductIds.MolokhiaWithChicken,
                    Name = "ملوخية بالفراخ - حصة متوسطة",
                    Price = 65.00m,
                    CompareAtPrice = 75.00m,
                    CostPrice = 40.00m,
                    InventoryQuantity = 50,
                    LowStockThreshold = 10,
                    Weight = 500,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.MolokhiaChickenLarge,
                    ProductId = ProductIds.MolokhiaWithChicken,
                    Name = "ملوخية بالفراخ - حصة كبيرة",
                    Price = 85.00m,
                    CompareAtPrice = 95.00m,
                    CostPrice = 55.00m,
                    InventoryQuantity = 50,
                    LowStockThreshold = 10,
                    Weight = 700,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // فول مدمس
                new ProductVariant
                {
                    Id = ProductVariantIds.FulSandwich,
                    ProductId = ProductIds.FulMedames,
                    Name = "فول ساندويتش",
                    Price = 10.00m,
                    CompareAtPrice = 12.00m,
                    CostPrice = 5.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 200,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.FulPlate,
                    ProductId = ProductIds.FulMedames,
                    Name = "فول طبق",
                    Price = 15.00m,
                    CompareAtPrice = 18.00m,
                    CostPrice = 8.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 300,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // مشويات مشكلة
                new ProductVariant
                {
                    Id = ProductVariantIds.MixedGrillSmall,
                    ProductId = ProductIds.MixedGrill,
                    Name = "مشويات مشكلة - حصة صغيرة",
                    Price = 120.00m,
                    CompareAtPrice = 140.00m,
                    CostPrice = 80.00m,
                    InventoryQuantity = 30,
                    LowStockThreshold = 10,
                    Weight = 400,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.MixedGrillMedium,
                    ProductId = ProductIds.MixedGrill,
                    Name = "مشويات مشكلة - حصة متوسطة",
                    Price = 180.00m,
                    CompareAtPrice = 200.00m,
                    CostPrice = 120.00m,
                    InventoryQuantity = 30,
                    LowStockThreshold = 10,
                    Weight = 600,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.MixedGrillLarge,
                    ProductId = ProductIds.MixedGrill,
                    Name = "مشويات مشكلة - حصة كبيرة",
                    Price = 240.00m,
                    CompareAtPrice = 260.00m,
                    CostPrice = 160.00m,
                    InventoryQuantity = 30,
                    LowStockThreshold = 10,
                    Weight = 800,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // كنافة
                new ProductVariant
                {
                    Id = ProductVariantIds.KunafaSlice,
                    ProductId = ProductIds.Kunafa,
                    Name = "كنافة - قطعة",
                    Price = 25.00m,
                    CompareAtPrice = 30.00m,
                    CostPrice = 15.00m,
                    InventoryQuantity = 50,
                    LowStockThreshold = 10,
                    Weight = 150,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.KunafaBox,
                    ProductId = ProductIds.Kunafa,
                    Name = "كنافة - علبة",
                    Price = 180.00m,
                    CompareAtPrice = 200.00m,
                    CostPrice = 120.00m,
                    InventoryQuantity = 20,
                    LowStockThreshold = 5,
                    Weight = 1000,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // سمك قاروص
                new ProductVariant
                {
                    Id = ProductVariantIds.SeabassSmall,
                    ProductId = ProductIds.GrilledSeabass,
                    Name = "قاروص مشوي - حصة صغيرة",
                    Price = 100.00m,
                    CompareAtPrice = 120.00m,
                    CostPrice = 70.00m,
                    InventoryQuantity = 30,
                    LowStockThreshold = 10,
                    Weight = 250,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.SeabassMedium,
                    ProductId = ProductIds.GrilledSeabass,
                    Name = "قاروص مشوي - حصة متوسطة",
                    Price = 160.00m,
                    CompareAtPrice = 180.00m,
                    CostPrice = 100.00m,
                    InventoryQuantity = 30,
                    LowStockThreshold = 10,
                    Weight = 400,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.SeabassLarge,
                    ProductId = ProductIds.GrilledSeabass,
                    Name = "قاروص مشوي - حصة كبيرة",
                    Price = 220.00m,
                    CompareAtPrice = 240.00m,
                    CostPrice = 150.00m,
                    InventoryQuantity = 30,
                    LowStockThreshold = 10,
                    Weight = 600,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // فراخ مشوية
                new ProductVariant
                {
                    Id = ProductVariantIds.ChickenQuarterLight,
                    ProductId = ProductIds.GrilledChicken,
                    Name = "ربع فراخ - قطعة فاتحة",
                    Price = 50.00m,
                    CompareAtPrice = 60.00m,
                    CostPrice = 30.00m,
                    InventoryQuantity = 50,
                    LowStockThreshold = 10,
                    Weight = 250,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.ChickenQuarterDark,
                    ProductId = ProductIds.GrilledChicken,
                    Name = "ربع فراخ - قطعة داكنة",
                    Price = 55.00m,
                    CompareAtPrice = 65.00m,
                    CostPrice = 35.00m,
                    InventoryQuantity = 50,
                    LowStockThreshold = 10,
                    Weight = 250,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.ChickenWhole,
                    ProductId = ProductIds.GrilledChicken,
                    Name = "دجاجة كاملة مشوية",
                    Price = 90.00m,
                    CompareAtPrice = 100.00m,
                    CostPrice = 60.00m,
                    InventoryQuantity = 30,
                    LowStockThreshold = 5,
                    Weight = 1000,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // كفتة
                new ProductVariant
                {
                    Id = ProductVariantIds.KoftaPlate,
                    ProductId = ProductIds.KoftaMeat,
                    Name = "كفتة طبق",
                    Price = 85.00m,
                    CompareAtPrice = 95.00m,
                    CostPrice = 55.00m,
                    InventoryQuantity = 50,
                    LowStockThreshold = 10,
                    Weight = 300,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.KoftaSandwich,
                    ProductId = ProductIds.KoftaMeat,
                    Name = "كفتة ساندويتش",
                    Price = 40.00m,
                    CompareAtPrice = 45.00m,
                    CostPrice = 25.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 200,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                // حواوشي
                new ProductVariant
                {
                    Id = ProductVariantIds.HawawshiSmall,
                    ProductId = ProductIds.Hawawshi,
                    Name = "حواوشي صغير",
                    Price = 30.00m,
                    CompareAtPrice = 35.00m,
                    CostPrice = 20.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 200,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ProductVariant
                {
                    Id = ProductVariantIds.HawawshiLarge,
                    ProductId = ProductIds.Hawawshi,
                    Name = "حواوشي كبير",
                    Price = 40.00m,
                    CompareAtPrice = 45.00m,
                    CostPrice = 25.00m,
                    InventoryQuantity = 100,
                    LowStockThreshold = 20,
                    Weight = 300,
                    WeightUnit = "جرام",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
        }
    }
}
