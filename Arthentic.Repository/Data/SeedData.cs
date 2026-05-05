using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Arthentic.Entities;

namespace Arthentic.Repository.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ArthenticDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            await context.Database.MigrateAsync();

            // Seed Roles
            string[] roleNames = { "Admin", "Artist", "Customer" };
            foreach (var roleName in roleNames)
            {
                if (!await context.Roles.AnyAsync(r => r.Name == roleName))
                {
                    context.Roles.Add(new Role
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    });
                }
            }
            await context.SaveChangesAsync();

            // Seed Admin
            var admin = await userManager.FindByNameAsync("admin001");
            if (admin == null)
            {
                admin = new User
                {
                    UserName = "admin001",
                    Email = "admin@arthentic.com",
                    FullName = "Administrator",
                    IsActive = true
                };
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Seed Artists
            if (!await context.Artists.AnyAsync())
            {
                context.Artists.AddRange(
                    new Artist { FullName = "Nguyễn Văn A", Bio = "Họa sĩ tranh dầu", YearsOfExperience = 15, Nationality = "Việt Nam" },
                    new Artist { FullName = "Trần Thị B", Bio = "Chuyên tranh thủy mặc", YearsOfExperience = 10, Nationality = "Việt Nam" }
                );
                await context.SaveChangesAsync();
            }

            // Seed nhiều tranh hơn
            if (!await context.Paintings.AnyAsync())
            {
                var paintings = new List<Painting>
                {
                    new Painting { Title = "Hồ Tây Vào Sáng", Description = "Phong cảnh Hà Nội", Price = 8500000, DiscountPrice = 7200000, Width = 80, Height = 60, Medium = "Dầu", YearCreated = 2025, MainImageUrl = "https://picsum.photos/id/1015/800/600", ArtistId = context.Artists.First().Id, CategoryId = context.Categories.First().Id, IsAvailable = true, IsFeatured = true },
                    new Painting { Title = "Núi non hùng vĩ", Description = "Tranh thủy mặc", Price = 12500000, Width = 120, Height = 80, Medium = "Thủy mặc", YearCreated = 2024, MainImageUrl = "https://picsum.photos/id/133/800/600", ArtistId = context.Artists.Skip(1).First().Id, CategoryId = context.Categories.Skip(1).First().Id, IsAvailable = true },
                    new Painting { Title = "Hoa Sen Việt Nam", Description = "Tranh acrylic", Price = 6500000, Width = 70, Height = 70, Medium = "Acrylic", YearCreated = 2025, MainImageUrl = "https://picsum.photos/id/201/800/600", ArtistId = context.Artists.First().Id, CategoryId = context.Categories.First().Id, IsAvailable = true },
                    new Painting { Title = "Phố Cổ Hà Nội", Description = "Tranh dầu", Price = 9500000, Width = 90, Height = 60, Medium = "Dầu", YearCreated = 2023, MainImageUrl = "https://picsum.photos/id/251/800/600", ArtistId = context.Artists.First().Id, CategoryId = context.Categories.Skip(2).First().Id, IsAvailable = true }
                };

                context.Paintings.AddRange(paintings);
                await context.SaveChangesAsync();
            }

            Console.WriteLine("✅ Seed Data (nhiều tranh) completed successfully!");
        }
    }
}