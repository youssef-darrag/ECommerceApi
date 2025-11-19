namespace ECommerce.Core.Models
{
    public class Review
    {
        public string Id { get; set; } = Ulid.NewUlid().ToString();
        public string ProductId { get; set; } = default!;
        public required Product Product { get; set; }
        public string CustomerId { get; set; } = default!;
        public required Customer Customer { get; set; }
        public string? OrderId { get; set; }
        public Order? Order { get; set; } = null!;
        public required int Rating { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
