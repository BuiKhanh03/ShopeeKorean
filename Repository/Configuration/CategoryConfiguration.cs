using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeKorean.Entities.Models;


namespace ShopeeKorean.Repository.Configuration
{
    public class CategoryConfiguration : ConfigurationBase<Category>
    {
        protected override void ModelCreating(EntityTypeBuilder<Category> entity)
        {
           entity.HasKey(x => x.Id).HasName("category_id_primary");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Name).HasMaxLength(255);
        }
    }
}
