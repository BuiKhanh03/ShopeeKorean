using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Configuration
{
    public class OrderItemConfiguration : ConfigurationBase<OrderItem>
    {
        protected override void ModelCreating(EntityTypeBuilder<OrderItem> entity)
        {
            entity.HasKey(e => e.Id).HasName("orderitem_id_primary");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            entity.HasOne(e => e.Order)
                  .WithMany(e => e.OrderItems)
                  .HasForeignKey(e => e.OrderId)
                  .HasConstraintName("FK_OrderItem_Order");
            entity.HasOne(e => e.Product)
                   .WithMany(p => p.OrderItem)
                  .HasForeignKey(e => e.ProductId)
                  .HasConstraintName("FK_OrderItem_Product");
        }
    }
}
