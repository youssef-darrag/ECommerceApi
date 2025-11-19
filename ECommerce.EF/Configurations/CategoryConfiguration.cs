using ECommerce.Core.Constants;
using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.EF.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .HasMaxLength(26) // ULID length
                .ValueGeneratedNever(); // ULID is generated in the entity

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .IsRequired();

            builder.Property(c => c.ParentCategoryId)
                .HasMaxLength(26); // ULID length

            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.ProductCategories)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(LoadCategories());
        }

        private IEnumerable<Category> LoadCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = CategoryIds.TraditionalEgyptianFood,
                    Name = "مأكولات مصرية تقليدية",
                    Description = "أشهر الأطباق المصرية التقليدية والشعبية",
                    ImageUrl = "https://foodimages.store/egyptian/traditional.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    Id = CategoryIds.GrilledFoods,
                    Name = "مشويات",
                    Description = "تشكيلة متنوعة من المشويات المصرية",
                    ImageUrl = "https://foodimages.store/grilled/meats.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.OrientalSweets,
                    Name = "حلويات شرقية",
                    Description = "حلويات مصرية تقليدية وعربية",
                    ImageUrl = "https://foodimages.store/sweets/oriental.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.Bakery,
                    Name = "مخبوزات",
                    Description = "الخبز والمعجنات المصرية",
                    ImageUrl = "https://foodimages.store/bakery/bread.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.Seafood,
                    Name = "مأكولات بحرية",
                    Description = "أطباق السمك والمأكولات البحرية",
                    ImageUrl = "https://foodimages.store/seafood/fish.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.Breakfast,
                    Name = "وجبات فطور",
                    Description = "أطباق الفطور المصرية التقليدية",
                    ImageUrl = "https://foodimages.store/breakfast/traditional.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.Appetizers,
                    Name = "مقبلات",
                    Description = "المقبلات والسلطات المصرية",
                    ImageUrl = "https://foodimages.store/appetizers/salads.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.Soups,
                    Name = "حساء وشوربة",
                    Description = "أنواع الحساء والشوربة المصرية",
                    ImageUrl = "https://foodimages.store/soups/traditional.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.RiceDishes,
                    Name = "أطباق الأرز",
                    Description = "تشكيلة متنوعة من أطباق الأرز",
                    ImageUrl = "https://foodimages.store/rice/dishes.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.PastaDishes,
                    Name = "مكرونة وعجائن",
                    Description = "أطباق المكرونة والعجائن المصرية",
                    ImageUrl = "https://foodimages.store/pasta/dishes.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.VegetablesAndLegumes,
                    Name = "خضروات وبقوليات",
                    Description = "أطباق الخضروات والبقوليات المصرية",
                    ImageUrl = "https://foodimages.store/vegetables/legumes.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.HotBeverages,
                    Name = "مشروبات ساخنة",
                    Description = "المشروبات الساخنة التقليدية",
                    ImageUrl = "https://foodimages.store/beverages/hot.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.NaturalJuices,
                    Name = "عصائر طبيعية",
                    Description = "العصائر الطبيعية والمشروبات الباردة",
                    ImageUrl = "https://foodimages.store/beverages/juices.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.ChickenDishes,
                    Name = "أطباق الدجاج",
                    Description = "تشكيلة متنوعة من أطباق الدجاج",
                    ImageUrl = "https://foodimages.store/chicken/dishes.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.MeatDishes,
                    Name = "أطباق اللحوم",
                    Description = "أطباق اللحوم المصرية المتنوعة",
                    ImageUrl = "https://foodimages.store/meat/dishes.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.VegetarianDishes,
                    Name = "وجبات نباتية",
                    Description = "أطباق نباتية مصرية صحية",
                    ImageUrl = "https://foodimages.store/vegetarian/dishes.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.Pickles,
                    Name = "مخللات",
                    Description = "المخللات المصرية التقليدية",
                    ImageUrl = "https://foodimages.store/pickles/traditional.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.SpicesAndSeasonings,
                    Name = "توابل وبهارات",
                    Description = "التوابل والبهارات المصرية",
                    ImageUrl = "https://foodimages.store/spices/traditional.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.SaucesAndDips,
                    Name = "صلصات ومقبلات",
                    Description = "الصلصات والمقبلات المصرية",
                    ImageUrl = "https://foodimages.store/sauces/dips.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                },
                new Category
                {
                    Id = CategoryIds.FastFood,
                    Name = "وجبات سريعة",
                    Description = "الوجبات السريعة المصرية",
                    ImageUrl = "https://foodimages.store/fastfood/egyptian.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ParentCategoryId = CategoryIds.TraditionalEgyptianFood
                }
            };
        }
    }
}
