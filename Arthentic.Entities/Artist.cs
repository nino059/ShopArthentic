using Arthentic.Entities.Common;

namespace Arthentic.Entities
{
    public class Artist : BaseEntity
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Nationality { get; set; }
        public int YearsOfExperience { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }

        // Navigation
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
    }
}