namespace ECommerce.Core.Models
{
    public class Coupon
    {
        public string Id { get; set; } = Ulid.NewUlid().ToString();
        public required string Code { get; set; }
        public required string Description { get; set; }
        public required string DiscountType { get; set; }
        public required decimal DiscountValue { get; set; }
        public decimal? MinimumPurchase { get; set; }
        public int? UsageLimit { get; set; }
        public required int UsageCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required bool IsActive { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public required ICollection<Order> Orders { get; set; }
    }
}
