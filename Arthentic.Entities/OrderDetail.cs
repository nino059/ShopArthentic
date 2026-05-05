using System.ComponentModel.DataAnnotations.Schema;

namespace Arthentic.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid PaintingId { get; set; }
        public Painting Painting { get; set; } = null!;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountPrice { get; set; }

        [NotMapped]
        public decimal Subtotal => (UnitPrice - (DiscountPrice ?? 0)) * Quantity;
    }
}