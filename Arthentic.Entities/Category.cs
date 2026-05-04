using Arthentic.Entities.Common;

namespace Arthentic.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
    }
}