using Microsoft.EntityFrameworkCore;
using ShopMeneger.Data.Models;

namespace ShopShopMeneger.Data.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Shop> Shops => Set<Shop>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(k => k.ShopId);

                entity.Property(p => p.ShopName)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(p => p.ShopDescription)
                .HasMaxLength(500);
            });
        }
    }
}
