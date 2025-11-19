namespace ECommerce.Core.Models
{
    public class ProductImage
    {
        public string Id { get; set; } = Ulid.NewUlid().ToString();
        public string ProductId { get; set; } = default!;
        public Product Product { get; set; } = null!;
        public string? VariantId { get; set; }
        public ProductVariant? Variant { get; set; }
        public required string ImageUrl { get; set; }
        public required string AltText { get; set; }
        public required int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
