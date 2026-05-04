using Arthentic.Entities.Common;

namespace Arthentic.Entities
{
    public class Order : BaseEntity
    {
        public string OrderCode { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Shipping, Delivered, Cancelled
        public string? ShippingAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Note { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}