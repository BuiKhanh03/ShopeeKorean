using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class ReviewConfiguration : ConfigurationBase<Review>
    {
        protected override void ModelCreating(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(e => e.Id).HasName("review_id_primary");

            entity.ToTable("Review");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(r => r.Rating)
             .IsRequired();
            entity.Property(e => e.Comment).HasMaxLength(1000);

            entity.HasIndex(r => new { r.UserId, r.ProductId })
                  .IsUnique()
                  .HasDatabaseName("UX_Review_User_Product");

            entity.HasOne(e => e.Product)
                  .WithMany(e => e.Reviews)
                  .HasForeignKey(e => e.ProductId);

            entity.HasOne(r => r.User)
                  .WithMany(u => u.Reviews)
                  .HasForeignKey(r => r.UserId)
                  .HasConstraintName("FK_Review_User");


        }
    }
}
