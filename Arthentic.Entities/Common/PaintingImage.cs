using Arthentic.Entities.Common;

namespace Arthentic.Entities
{
    public class PaintingImage : BaseEntity
    {
        public Guid PaintingId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? Caption { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public bool IsMainImage { get; set; } = false;

        public virtual Painting Painting { get; set; } = null!;
    }
}