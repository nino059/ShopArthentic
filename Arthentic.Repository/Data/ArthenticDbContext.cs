using Arthentic.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arthentic.Repository.Data
{
    public class ArthenticDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ArthenticDbContext(DbContextOptions<ArthenticDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<PaintingImage> PaintingImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình một số relationship
            modelBuilder.Entity<Painting>()
                .HasOne(p => p.Artist)
                .WithMany(a => a.Paintings)
                .HasForeignKey(p => p.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Painting>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Paintings)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
        }
    }
}