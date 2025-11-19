namespace ECommerce.Core.Models
{
    public class Wishlist
    {
        public string Id { get; set; } = Ulid.NewUlid().ToString();
        public string CustomerId { get; set; } = default!;
        public required Customer Customer { get; set; }
        public string ProductId { get; set; } = default!;
        public required Product Product { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
