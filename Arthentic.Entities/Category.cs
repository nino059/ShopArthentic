namespace Arthentic.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
        public int DisplayOrder { get; set; } = 0;
    }
}