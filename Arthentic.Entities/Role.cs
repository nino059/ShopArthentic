using Microsoft.AspNetCore.Identity;

namespace Arthentic.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}