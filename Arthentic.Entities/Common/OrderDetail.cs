using Arthentic.Entities.Common;

namespace Arthentic.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid PaintingId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? DiscountPrice { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Painting Painting { get; set; } = null!;
    }
}