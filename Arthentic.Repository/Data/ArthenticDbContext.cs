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

            // Auto generate OrderCode
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderCode)
                .HasDefaultValueSql("CONCAT('ORD', DATE_FORMAT(NOW(), '%Y%m%d'), LPAD(FLOOR(RAND()*10000), 4, '0'))");
        }
    }
}