using Arthentic.Entities;
using Arthentic.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arthentic.Repository.Data
{
    public class ArthenticDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
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

            // === FIX CASCADE DELETE CONFLICTS ===

            // OrderDetail -> Order (cascade)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // OrderDetail -> Painting (restrict)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Painting)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.PaintingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Painting -> Artist (cascade)
            modelBuilder.Entity<Painting>()
                .HasOne(p => p.Artist)
                .WithMany(a => a.Paintings)
                .HasForeignKey(p => p.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            // Painting -> Category (restrict)
            modelBuilder.Entity<Painting>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Paintings)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Review -> User (cascade)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Review -> Painting (restrict)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Painting)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PaintingId)
                .OnDelete(DeleteBehavior.Restrict);

            // PaintingImage -> Painting (cascade)
            modelBuilder.Entity<PaintingImage>()
                .HasOne(pi => pi.Painting)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.PaintingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}