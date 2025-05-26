using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Configuration
{
    public class RolesConfiguration : ConfigurationBase<Roles>
    {
        protected override void SeedData(EntityTypeBuilder<Roles> entity)
        {
            entity.HasData(
        new Roles
        {
            Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
            Name = "Manager",
            NormalizedName = "MANAGER"
        },
        new Roles
        {
            Id = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        });
        }
    }
}
