using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class PaymentRecordConfiguration : ConfigurationBase<PaymentRecord>
    {
        protected override void ModelCreating(EntityTypeBuilder<PaymentRecord> entity)
        {
            entity.HasKey(e => e.Id).HasName("paymentrecord_id_primary");

            entity.ToTable("paymentrecord");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.PaymentRecordMethod).HasMaxLength(255);
            entity.Property(e => e.PaymentRecordStatus).HasMaxLength(255);
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 2)");
        }
    }
}
