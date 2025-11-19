using ECommerce.Core.Constants;
using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever(); // ULID is generated in the entity

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(p => p.ShortDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CompareAtPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CostPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .IsRequired();

            builder.HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Variants)
                .WithOne(v => v.Product)
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(LoadProducts());
        }

        private IEnumerable<Product> LoadProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = ProductIds.KosharyClassic,
                    Name = "كشري مصري تقليدي",
                    Description = "كشري مصري تقليدي مكون من عدس وأرز ومكرونة وصلصة طماطم حارة",
                    ShortDescription = "طبق مصري شعبي مميز",
                    Price = 35.00m,
                    CompareAtPrice = 40.00m,
                    CostPrice = 20.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.MolokhiaWithChicken,
                    Name = "ملوخية بالفراخ",
                    Description = "ملوخية خضراء طازجة مع قطع دجاج مشوي وأرز",
                    ShortDescription = "طبق مصري عائلي مميز",
                    Price = 65.00m,
                    CompareAtPrice = 75.00m,
                    CostPrice = 40.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.FulMedames,
                    Name = "فول مدمس",
                    Description = "فول مدمس بزيت الزيتون والكمون والليمون",
                    ShortDescription = "فطار مصري تقليدي",
                    Price = 15.00m,
                    CompareAtPrice = 18.00m,
                    CostPrice = 8.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.MixedGrill,
                    Name = "مشويات مشكلة",
                    Description = "تشكيلة من اللحوم المشوية تشمل كفتة وريش وشيش طاووق",
                    ShortDescription = "مشويات مصرية فاخرة",
                    Price = 180.00m,
                    CompareAtPrice = 200.00m,
                    CostPrice = 120.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.Kunafa,
                    Name = "كنافة نابلسية",
                    Description = "كنافة محشوة بالقشطة والمكسرات",
                    ShortDescription = "حلوى شرقية شهية",
                    Price = 45.00m,
                    CompareAtPrice = 50.00m,
                    CostPrice = 25.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.BaladiBread,
                    Name = "عيش بلدي",
                    Description = "خبز بلدي طازج مصنوع يومياً",
                    ShortDescription = "خبز مصري تقليدي",
                    Price = 2.00m,
                    CompareAtPrice = 2.50m,
                    CostPrice = 1.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.GrilledSeabass,
                    Name = "سمك قاروص مشوي",
                    Description = "سمك قاروص طازج مشوي مع الخضروات والصلصة",
                    ShortDescription = "سمك طازج مشوي",
                    Price = 160.00m,
                    CompareAtPrice = 180.00m,
                    CostPrice = 100.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.FattahWithMeat,
                    Name = "فتة باللحمة",
                    Description = "فتة مصرية باللحم البتلو والخل والثوم",
                    ShortDescription = "طبق مصري تقليدي",
                    Price = 85.00m,
                    CompareAtPrice = 95.00m,
                    CostPrice = 55.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.BabaGhanoush,
                    Name = "بابا غنوج",
                    Description = "متبل باذنجان مشوي بالطحينة والثوم",
                    ShortDescription = "مقبلات شرقية",
                    Price = 25.00m,
                    CompareAtPrice = 30.00m,
                    CostPrice = 15.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.LentilSoup,
                    Name = "شوربة عدس",
                    Description = "شوربة عدس مصرية بالكمون والليمون",
                    ShortDescription = "شوربة مصرية تقليدية",
                    Price = 20.00m,
                    CompareAtPrice = 25.00m,
                    CostPrice = 10.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.SayyadiaRice,
                    Name = "أرز صيادية",
                    Description = "أرز صيادية بالسمك والمكسرات",
                    ShortDescription = "أرز بالسمك على الطريقة المصرية",
                    Price = 45.00m,
                    CompareAtPrice = 50.00m,
                    CostPrice = 25.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.AlexandriaPasta,
                    Name = "مكرونة إسكندراني",
                    Description = "مكرونة بالجمبري والصلصة البيضاء",
                    ShortDescription = "باستا على الطريقة الإسكندرانية",
                    Price = 70.00m,
                    CompareAtPrice = 80.00m,
                    CostPrice = 45.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.EgyptianTea,
                    Name = "شاي مصري",
                    Description = "شاي مصري أسود مع النعناع الطازج",
                    ShortDescription = "مشروب مصري تقليدي",
                    Price = 5.00m,
                    CompareAtPrice = 7.00m,
                    CostPrice = 2.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.SugarCaneJuice,
                    Name = "عصير قصب",
                    Description = "عصير قصب طازج",
                    ShortDescription = "مشروب مصري منعش",
                    Price = 10.00m,
                    CompareAtPrice = 12.00m,
                    CostPrice = 5.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.GrilledChicken,
                    Name = "فراخ مشوية",
                    Description = "فراخ مشوية متبلة بالتوابل المصرية",
                    ShortDescription = "دجاج مشوي على الفحم",
                    Price = 90.00m,
                    CompareAtPrice = 100.00m,
                    CostPrice = 60.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.KoftaMeat,
                    Name = "كفتة مشوية",
                    Description = "كفتة لحم مشوية مع البهارات المصرية",
                    ShortDescription = "لحم مفروم مشوي",
                    Price = 85.00m,
                    CompareAtPrice = 95.00m,
                    CostPrice = 55.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.MixedPickles,
                    Name = "مخلل مشكل",
                    Description = "تشكيلة من المخللات المصرية",
                    ShortDescription = "مخللات مصرية متنوعة",
                    Price = 15.00m,
                    CompareAtPrice = 18.00m,
                    CostPrice = 8.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.EgyptianSpiceMix,
                    Name = "دقة مصرية",
                    Description = "خلطة بهارات مصرية تقليدية",
                    ShortDescription = "توابل مصرية",
                    Price = 25.00m,
                    CompareAtPrice = 30.00m,
                    CostPrice = 12.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.TahiniSauce,
                    Name = "صلصة طحينة",
                    Description = "طحينة مصرية مع الليمون والثوم",
                    ShortDescription = "صلصة مصرية تقليدية",
                    Price = 20.00m,
                    CompareAtPrice = 25.00m,
                    CostPrice = 10.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = ProductIds.Hawawshi,
                    Name = "حواوشي",
                    Description = "حواوشي باللحم المفروم والتوابل",
                    ShortDescription = "ساندوتش مصري شهير",
                    Price = 40.00m,
                    CompareAtPrice = 45.00m,
                    CostPrice = 25.00m,
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
        }
    }
}
