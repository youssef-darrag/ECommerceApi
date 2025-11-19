namespace ECommerce.Core.Models
{
    public class Admin
    {
        public string Id { get; set; } = Ulid.NewUlid().ToString();
        public string ApplicationUserId { get; set; } = default!;
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public required string Position { get; set; }
    }
}
