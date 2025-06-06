using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class ProductConfiguration : ConfigurationBase<Product>
    {
        protected override void ModelCreating(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Id).HasName("product_id_primary");

            entity.ToTable("Product");

            entity.HasIndex(e => e.SellerId, "produc_sellerId_index");
            entity.HasIndex(e => e.CategoryId, "produc_categoryId_index");
            entity.HasIndex(e => e.Name, "product_name_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(e => e.Seller)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.SellerId)
                .HasConstraintName("FK_Product_Seller");

            entity.HasOne(e => e.Category)
                  .WithOne(e => e.Product)
                  .HasForeignKey<Product>(e => e.CategoryId)
                  .HasConstraintName("FK_Product_Category");
        }
    }
}