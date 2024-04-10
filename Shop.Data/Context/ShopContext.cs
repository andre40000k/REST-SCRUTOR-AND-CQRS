using Microsoft.EntityFrameworkCore;
using ShopMeneger.Data.Entitys;
using ShopMeneger.Application.Interfaces;

namespace ShopShopMeneger.Data.Context
{
    public class ShopContext : DbContext : IApplicationDbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Shop> Shops => Set<Shop>();
        public DbSet<ShopCategory> ShopCategories => Set<ShopCategory>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
            //modelBuilder.Entity<Shop>(entity =>
            //{
            //    entity.HasKey(k => k.ShopId);

            //    entity.Property(p => p.ShopName)
            //    .HasMaxLength(50)
            //    .IsRequired();

            //    entity.Property(p => p.ShopDescription)
            //    .HasMaxLength(500);
            //});
        }
    }
}
