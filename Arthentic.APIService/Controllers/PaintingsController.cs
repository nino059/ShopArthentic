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

        // Lấy danh sách tranh (giữ nguyên code cũ của bạn)
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
                {
                    query = query.Where(p => p.CategoryId == categoryId);
                }

                var totalItems = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                var paintings = await query
                    .OrderByDescending(p => p.CreatedAt)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var result = paintings.Select(p => new PaintingDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description ?? "",
                    Price = p.Price,
                    DiscountPrice = p.DiscountPrice,
                    Width = p.Width,
                    Height = p.Height,
                    Medium = p.Medium ?? "",
                    YearCreated = p.YearCreated,
                    MainImageUrl = p.MainImageUrl ?? "",
                    IsAvailable = p.IsAvailable,
                    IsFeatured = p.IsFeatured,
                    CreatedAt = p.CreatedAt,
                    ArtistName = p.Artist != null ? p.Artist.FullName : "Unknown Artist",
                    CategoryName = p.Category != null ? p.Category.Name : "Uncategorized"
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
                return StatusCode(500, new { message = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        // ==================== THÊM MỚI ====================
        // Lấy chi tiết một bức tranh (dùng khi click vào tranh)
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PaintingDto>> GetById(Guid id)
        {
            try
            {
                var painting = await _context.Paintings
                    .Include(p => p.Artist)
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.Id == id && p.IsAvailable && !p.IsDeleted);

                if (painting == null)
                    return NotFound(new { message = "Không tìm thấy bức tranh" });

                var dto = new PaintingDto
                {
                    Id = painting.Id,
                    Title = painting.Title,
                    Description = painting.Description ?? "",
                    Price = painting.Price,
                    DiscountPrice = painting.DiscountPrice,
                    Width = painting.Width,
                    Height = painting.Height,
                    Medium = painting.Medium ?? "",
                    YearCreated = painting.YearCreated,
                    MainImageUrl = painting.MainImageUrl ?? "",
                    IsAvailable = painting.IsAvailable,
                    IsFeatured = painting.IsFeatured,
                    CreatedAt = painting.CreatedAt,
                    ArtistName = painting.Artist != null ? painting.Artist.FullName : "Unknown Artist",
                    CategoryName = painting.Category != null ? painting.Category.Name : "Uncategorized"
                };

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}