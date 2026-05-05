using Arthentic.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            string[] roles = { "Admin", "Artist", "Customer" };
            foreach (var role in roles)
            {
                if (!await context.Roles.AnyAsync(r => r.Name == role))
                {
                    await context.Roles.AddAsync(new Role { Name = role, NormalizedName = role.ToUpper() });
                }
            }
            await context.SaveChangesAsync();

            // Seed Admin Account (username bắt đầu bằng "admin")
            var adminEmail = "admin@arthentic.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin001",
                    Email = adminEmail,
                    FullName = "Administrator",
                    EmailConfirmed = true,
                    IsActive = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed một số Category mẫu
            if (!await context.Categories.AnyAsync())
            {
                context.Categories.AddRange(
                    new Category { Name = "Tranh Dầu", DisplayOrder = 1 },
                    new Category { Name = "Tranh Thủy Mặc", DisplayOrder = 2 },
                    new Category { Name = "Tranh Acrylic", DisplayOrder = 3 },
                    new Category { Name = "Nhiếp Ảnh Nghệ Thuật", DisplayOrder = 4 }
                );
                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }
    }
}   