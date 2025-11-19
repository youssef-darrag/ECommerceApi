using ECommerce.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ILogger<ApplicationDbContext> _logger;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Wishlist> WishlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _logger.LogInformation("Applying entity configurations from assembly.");

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            _logger.LogInformation("Entity configurations applied successfully.");

            // Seed Roles with specific IDs to prevent duplicates
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Ulid.NewUlid().ToString()
            },
            new IdentityRole
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = Ulid.NewUlid().ToString()
            });

            _logger.LogInformation("Seeding initial roles completed.");
        }
    }
}
