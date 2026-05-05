namespace Arthentic.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid PaintingId { get; set; }
        public Painting Painting { get; set; } = null!;

        public int Rating { get; set; } // 1 đến 5
        public string Comment { get; set; } = string.Empty;

        public new DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}