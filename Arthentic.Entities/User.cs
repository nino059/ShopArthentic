using Arthentic.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace Arthentic.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public bool IsArtist { get; set; } = false;

        // Navigation
        public virtual Artist? ArtistProfile { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}