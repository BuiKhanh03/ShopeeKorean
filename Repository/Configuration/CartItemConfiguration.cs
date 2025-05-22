using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class CartItemConfiguration : ConfigurationBase<CartItem>
    {
        protected override void ModelCreating(EntityTypeBuilder<CartItem> entity)
        {
            entity.HasKey(e => e.Id).HasName("cartitem_id_primary");

            entity.ToTable("CartItem");

            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasDefaultValueSql("NEWID()");
            entity.HasOne(e => e.Cart)
                  .WithMany(e => e.CartItems)
                  .HasForeignKey(e => e.CartId)
                  .HasConstraintName("FK_Cart_Item")
                  .OnDelete(DeleteBehavior.Cascade); 

            entity.HasOne(e => e.Product)
                  .WithMany(e => e.CartItems)
                  .HasForeignKey(e => e.ProductId)
                  .HasConstraintName("FK_CartItem_Product")
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
