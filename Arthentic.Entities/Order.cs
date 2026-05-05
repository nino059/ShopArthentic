using System.ComponentModel.DataAnnotations.Schema;

namespace Arthentic.Entities
{
    public class Order : BaseEntity
    {
        public string OrderCode { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountAmount { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Paid, Processing, Shipped, Completed, Cancelled
        public string? ShippingAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}