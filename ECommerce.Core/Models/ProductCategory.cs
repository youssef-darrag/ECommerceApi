namespace ECommerce.Core.Models
{
    public class ProductCategory
    {
        public string ProductId { get; set; } = default!;
        public Product Product { get; set; } = null!;
        public string CategoryId { get; set; } = default!;
        public Category Category { get; set; } = null!;
    }
}
