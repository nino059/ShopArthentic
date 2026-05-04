using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Arthentic.Entities;
using Arthentic.DTO;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _config;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }

    // ====================== ĐĂNG KÝ ======================
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (await _userManager.FindByNameAsync(request.UserName) != null)
            return BadRequest(new { message = "Tên tài khoản đã tồn tại" });

        if (await _userManager.FindByEmailAsync(request.Email) != null)
            return BadRequest(new { message = "Email đã tồn tại" });

        var user = new User
        {
            UserName = request.UserName,
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            IsArtist = false
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
            return Ok(new { message = "Đăng ký thành công" });

        return BadRequest(new { message = "Đăng ký thất bại", errors = result.Errors });
    }

    // ====================== ĐĂNG NHẬP ======================
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user == null)
            return Unauthorized(new { message = "Tài khoản hoặc mật khẩu không đúng" });

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
            return Unauthorized(new { message = "Tài khoản hoặc mật khẩu không đúng" });

        var token = GenerateJwtToken(user);

        return Ok(new AuthResponse
        {
            Token = token,
            UserName = user.UserName!,
            FullName = user.FullName,
            Role = user.IsArtist ? "Artist" : "User",
            IsArtist = user.IsArtist
        });
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim("FullName", user.FullName),
            new Claim("IsArtist", user.IsArtist.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}   