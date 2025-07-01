using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Configuration
{
    public class ShippingConfiguration : ConfigurationBase<Shipping>
    {
        protected override void ModelCreating(EntityTypeBuilder<Shipping> entity)
        {
            entity.HasKey(e => e.Id).HasName("shipping_id_primary");

            entity.ToTable("Shipping");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            entity.Property(e => e.Carrier).HasMaxLength(255);
            entity.Property(e => e.ShippingStatus).HasMaxLength(255);

        }
    }
}
