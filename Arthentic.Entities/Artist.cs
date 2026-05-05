namespace Arthentic.Entities
{
    public class Artist : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;     
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Nationality { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public int YearsOfExperience { get; set; } = 0;         // ← Thêm
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
    }
}