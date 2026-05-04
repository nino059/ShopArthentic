using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Arthentic.Repository.Data;
using Arthentic.Entities;

var builder = WebApplication.CreateBuilder(args);

// ======================
// 1. Cấu hình Database
// ======================
builder.Services.AddDbContext<ArthenticDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ======================
// 2. Identity
// ======================
// ======================
// Identity Configuration (Mật khẩu đơn giản cho dev)
// ======================
builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    // Tắt tất cả yêu cầu phức tạp về mật khẩu
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;           // Chỉ cần tối thiểu 6 ký tự
    options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<ArthenticDbContext>()
.AddDefaultTokenProviders();

// ======================
// 3. JWT Authentication
// ======================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

// ======================
// 4. CORS (cho Frontend React)
// ======================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ======================
// Middleware
// ======================
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");         

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();