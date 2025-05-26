using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    /*
    IEntityTypeConfiguration<T> là chuẩn kiến trúc nên dùng trong mọi dự án EF Core lớn, giúp:

        Cấu hình sạch sẽ

        Dễ quản lý khi dự án nhiều bảng (như Shopee clone của em)

        Hỗ trợ phân tầng (ví dụ dùng cùng BaseConfiguration<T> như em đang làm)
    */
    public abstract class ConfigurationBase<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> entity)
        {
            SeedData(entity);
            ModelCreating(entity);
        }

        protected virtual void SeedData(EntityTypeBuilder<T> entity) { }
        protected virtual void ModelCreating(EntityTypeBuilder<T> entity) { }
}
}
