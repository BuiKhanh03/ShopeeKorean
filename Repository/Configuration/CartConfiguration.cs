using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Configuration
{
    public class CartConfiguration : ConfigurationBase<Cart>
    {
        protected override void ModelCreating(EntityTypeBuilder<Cart> entity)
        {
            entity.HasKey(e => e.Id).HasName("cart_id_primary");

            entity.ToTable("Cart");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            entity.HasOne(e => e.User)
                  .WithOne(e => e.Cart)
                  .HasForeignKey<Cart>(e => e.UserId)
                  .HasConstraintName("FK_Cart_User");
        }
    }
}
