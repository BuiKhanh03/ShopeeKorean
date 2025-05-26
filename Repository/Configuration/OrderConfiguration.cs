using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class OrderConfiguration : ConfigurationBase<Order>
    {
        protected override void ModelCreating(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.Id).HasName("order_id_primary");

            entity.ToTable("Order");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShippingFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.ShippingAddress).HasMaxLength(255);


            entity.HasOne(e => e.PaymentRecord)
                  .WithOne(e => e.Order)
                  .HasForeignKey<Order>(e => e.PaymentRecordId)
                  .HasConstraintName("FK_Order_PaymentRecord");

            entity.HasOne(e => e.Shipping)
                  .WithOne(e => e.Order)
                  .HasForeignKey<Order>(e => e.ShippingId)
                  .HasConstraintName("FK_Order_Shipping");
        }
    }
}
