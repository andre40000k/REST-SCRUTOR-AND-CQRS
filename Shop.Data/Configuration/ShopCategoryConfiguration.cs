using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMeneger.Data.Entitys;

namespace ShopMeneger.Data.Configuration
{
    public class ShopCategoryConfiguration : IEntityTypeConfiguration<ShopCategory>
    {
        public void Configure(EntityTypeBuilder<ShopCategory> builder)
        {
            builder.HasKey(k => k.ShopCategoryId);
            builder.Property(p => p.ShopCategoryId).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Shop)
                .WithMany(c => c.ShopCategorys)
                .HasForeignKey(f => f.ShopId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Category)
                .WithMany(s => s.ShopCategories)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("ShopCategory");
        }
    }
}
