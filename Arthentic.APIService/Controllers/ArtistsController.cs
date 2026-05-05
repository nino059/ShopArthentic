using Arthentic.DTO;
using Arthentic.Repository.Data;
using Arthentic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arthentic.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArthenticDbContext _context;

        public ArtistsController(ArthenticDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDto>>> GetArtists()
        {
            var artists = await _context.Artists
                .Where(a => !a.IsDeleted)
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    Bio = a.Bio,
                    AvatarUrl = a.AvatarUrl,
                    Nationality = a.Nationality,
                    YearsOfExperience = a.YearsOfExperience
                })
                .ToListAsync();

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDto>> GetArtistById(Guid id)
        {
            var artist = await _context.Artists
                .Where(a => a.Id == id && !a.IsDeleted)
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    Bio = a.Bio,
                    AvatarUrl = a.AvatarUrl,
                    Nationality = a.Nationality,
                    YearsOfExperience = a.YearsOfExperience
                })
                .FirstOrDefaultAsync();

            if (artist == null) return NotFound();

            return Ok(artist);
        }
    }
}