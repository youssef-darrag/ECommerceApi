namespace ECommerce.Core.Models
{
    public class Address
    {
        public string Id { get; set; } = Ulid.NewUlid().ToString();
        public string CustomerId { get; set; } = default!;
        public required Customer Customer { get; set; }
        public required string AddressLine { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
