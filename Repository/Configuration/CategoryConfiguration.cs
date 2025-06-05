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
        protected override void SeedData(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category
                {
                    Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
                    Name = "Điện thoại & Phụ kiện"
                },
                 new Category
                 {
                     Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb738"),
                     Name = "Máy tính & Laptop"
                 },
                 new Category
                 {
                     Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb737"),
                     Name = "Thiết bị điện tử"
                 },
                 new Category
                 {
                     Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb736"),
                     Name = "Máy ảnh & Máy quay phim"
                 },
                  new Category
                  {
                      Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb735"),
                      Name = "Thời trang Nam"
                  },
                   new Category
                   {
                       Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb734"),
                       Name = "Thời trang Nữ"
                   },
                   new Category
                   {
                       Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb733"),
                       Name = "Mẹ & Bé"
                   },
                   new Category
                   {
                       Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb732"),
                       Name = "Nhà cửa & Đời sống"
                   },
                   new Category
                   {
                        Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb728"),
                        Name = "Sức khỏe & Làm đẹp"
                   },
                   new Category
                   {
                        Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb731"),
                        Name = "Giày dép Nam / Nữ"
                   },
                    new Category
                    {
                        Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb730"),
                        Name = "Túi xách / Balo"
                    },
                     new Category
                     {
                         Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb721"),
                         Name = "Đồng hồ & Trang sức"
                     },
                      new Category
                      {
                          Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb723"),
                          Name = "Thể thao & Dã ngoại"
                      },
                      new Category
                      {
                          Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb729"),
                          Name = "Ô tô - Xe máy - Xe đạp"
                      },
                      new Category
                      {
                          Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb724"),
                          Name = "Sách & Văn phòng phẩm"
                      },
                      new Category
                      {
                          Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb725"),
                          Name = "Thực phẩm & Đồ uống"
                      },
                       new Category
                       {
                           Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb711"),
                           Name = "Thiết bị gia dụng"
                       },
                       new Category
                       {
                           Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb712"),
                           Name = "Pet - Đồ dùng thú cưng"
                       },
                       new Category
                       {
                           Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb727"),
                           Name = "Game & Console"
                       }
                );
        }
    }
}
