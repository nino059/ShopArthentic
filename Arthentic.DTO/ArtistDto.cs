namespace Arthentic.DTO
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Nationality { get; set; }
        public int YearsOfExperience { get; set; }
    }
}