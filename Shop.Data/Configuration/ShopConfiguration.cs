using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMeneger.Data.Entitys;

namespace ShopMeneger.Data.Configuration
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(k => k.ShopId);
            builder.Property(p => p.ShopId).ValueGeneratedOnAdd();
            builder.Property(p => p.ShopName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ShopDescription).HasMaxLength(250);

            builder.ToTable("Shop");
        }
    }
}
