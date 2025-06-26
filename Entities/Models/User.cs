using Microsoft.AspNetCore.Identity;



namespace ShopeeKorean.Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public Cart Cart { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Roles> Roles { get; set; } = new List<Roles>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
