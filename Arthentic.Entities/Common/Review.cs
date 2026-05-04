using Arthentic.Entities.Common;

namespace Arthentic.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PaintingId { get; set; }
        public int Rating { get; set; } // 1-5
        public string Comment { get; set; } = string.Empty;

        public virtual User User { get; set; } = null!;
        public virtual Painting Painting { get; set; } = null!;
    }
}