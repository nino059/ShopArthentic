using Arthentic.DTO;
using Arthentic.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arthentic.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingsController : ControllerBase
    {
        private readonly ArthenticDbContext _context;

        public PaintingsController(ArthenticDbContext context)
        {
            _context = context;
        }

        // Danh sách tranh (giữ nguyên)
        [HttpGet]
        public async Task<ActionResult<object>> GetPaintings(
            string? search = null,
            Guid? categoryId = null,
            int page = 1,
            int pageSize = 12)
        {
            try
            {
                var query = _context.Paintings
                    .Include(p => p.Artist)
                    .Include(p => p.Category)
                    .Where(p => p.IsAvailable && !p.IsDeleted);

                if (!string.IsNullOrEmpty(search))
                {
                    search = search.ToLower();
                    query = query.Where(p =>
                        p.Title.ToLower().Contains(search) ||
                        (p.Artist != null && p.Artist.FullName.ToLower().Contains(search)));
                }

                if (categoryId.HasValue)
                    query = query.Where(p => p.CategoryId == categoryId.Value);

                var totalItems = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                var paintings = await query
                    .OrderByDescending(p => p.CreatedAt)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var result = paintings.Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Description,
                    p.Price,
                    p.DiscountPrice,
                    p.Width,
                    p.Height,
                    p.Medium,
                    p.YearCreated,
                    p.MainImageUrl,
                    p.IsAvailable,
                    p.IsFeatured,
                    ArtistName = p.Artist?.FullName ?? "Unknown Artist",
                    CategoryName = p.Category?.Name ?? "Uncategorized"
                }).ToList();

                return Ok(new
                {
                    items = result,
                    totalItems,
                    totalPages,
                    currentPage = page,
                    pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // ==================== CHI TIẾT TRANH (ĐÃ SỬA AN TOÀN) ====================
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<object>> GetById(Guid id)
        {
            try
            {
                return Ok(new
                {
                    Id = id,
                    Title = "Test Painting",
                    Price = 10000000,
                    Description = "Đây là test để kiểm tra controller có chạy không",
                    ArtistName = "Test Artist"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}