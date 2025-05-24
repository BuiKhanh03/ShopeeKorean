using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class ProductImageConfiguration : ConfigurationBase<ProductImage>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductImage> entity)
        {
            entity.HasKey(e => e.Id).HasName("productimage_id_primary");

            entity.ToTable("ProductImage");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);

            entity.HasOne(e => e.Product)
                .WithMany(e => e.ProductImages)
                .HasForeignKey(e => e.ProductId)
                .HasConstraintName("FK_Product_Image");
        }
    }
}
