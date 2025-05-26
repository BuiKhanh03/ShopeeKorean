using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class CouponConfiguration : ConfigurationBase<Coupon>
    {
        protected override void ModelCreating(EntityTypeBuilder<Coupon> entity)
        {
            entity.HasKey(e => e.Id).HasName("coupon_id_primary");

            entity.ToTable("Coupon");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Value).HasColumnName("decimal(18, 2)");
            entity.Property(e => e.MaxDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinOrderValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Value).HasMaxLength(255);

            entity.HasOne(e => e.Product)
                  .WithMany(e => e.Coupons)
                  .HasForeignKey(e => e.ProductId)
                  .HasConstraintName("FK_Coupon_Product");

        }
    }
}
