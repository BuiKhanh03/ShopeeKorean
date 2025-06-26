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


            entity.HasOne(o => o.PaymentRecord)
                  .WithMany()
                  .HasForeignKey(o => o.PaymentRecordId)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.NoAction)
                  .HasConstraintName("FK_Order_PaymentRecord");

            entity.HasOne(o => o.Shipping)
                  .WithMany()
                  .HasForeignKey(o => o.ShippingId)
                  .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                  .HasConstraintName("FK_Order_Shipping");
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Orders)
                  .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction)
                  .HasConstraintName("FK_Order_User");
        }
    }
}
