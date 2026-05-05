namespace Arthentic.Entities
{
    public class PaintingImage : BaseEntity
    {
        public Guid PaintingId { get; set; }
        public Painting Painting { get; set; } = null!;

        public string ImageUrl { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public bool IsMain { get; set; } = false;
    }
}