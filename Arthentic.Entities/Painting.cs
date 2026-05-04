using Arthentic.Entities.Common;

namespace Arthentic.Entities
{
    public class Painting : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }

        public int Width { get; set; }      // cm
        public int Height { get; set; }     // cm
        public string Medium { get; set; } = string.Empty; // Chất liệu (Dầu, Acrylic, Watercolor...)
        public int YearCreated { get; set; }

        public Guid ArtistId { get; set; }
        public Guid CategoryId { get; set; }

        public string? MainImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsFeatured { get; set; } = false;

        // Navigation
        public virtual Artist Artist { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<PaintingImage> Images { get; set; } = new List<PaintingImage>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}