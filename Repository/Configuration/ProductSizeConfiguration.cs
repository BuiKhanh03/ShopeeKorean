using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Configuration
{
    public class ProductSizeConfiguration : ConfigurationBase<ProductSize>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductSize> entity)
        {
            entity.HasKey(e => e.Id).HasName("productsize_id_primary");

            entity.ToTable("productsize");
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.size).HasMaxLength(255);
        }
    }
}
