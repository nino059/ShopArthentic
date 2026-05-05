namespace Arthentic.DTO
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int DisplayOrder { get; set; }     
        public int? PageIndex { get; set;} 
        public int? PageSize { get; set; }
    }
}