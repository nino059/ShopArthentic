namespace Arthentic.DTO
{
    public class PaintingDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Medium { get; set; } = string.Empty;
        public int YearCreated { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }

        // Thông tin rút gọn
        public string ArtistName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
     
       
    }
}