using System.ComponentModel.DataAnnotations.Schema;

namespace Arthentic.Entities
{
    public class Painting : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Width { get; set; }      // cm
        public int Height { get; set; }     // cm
        public string? Medium { get; set; } // Chất liệu (Dầu, Acrylic, Watercolor...)
        public int YearCreated { get; set; }

        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public string? MainImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsFeatured { get; set; } = false;

        // Navigation
        public virtual ICollection<PaintingImage> Images { get; set; } = new List<PaintingImage>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}