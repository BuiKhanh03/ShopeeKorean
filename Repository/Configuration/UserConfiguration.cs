using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopeeKorean.Repository.Configuration
{
    public class UserConfiguration : ConfigurationBase<User>
    {
        protected override void ModelCreating(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id).HasName("users_id_primary");
            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();
            entity.HasIndex(e => e.PhoneNumber, "users_phonenumber_unique").IsUnique();
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.NormalizedEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(25);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.SecurityStamp).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(25);
            entity.HasMany(u => u.Roles)
                  .WithMany(r => r.Users)
                  .UsingEntity<IdentityUserRole<Guid>>(
                  j => j.HasOne<Roles>().WithMany().HasForeignKey(ur => ur.RoleId),
                  j => j.HasOne<User>().WithMany().HasForeignKey(ur => ur.UserId),
                  j =>
                  {
                  j.HasKey(ur => new { ur.UserId, ur.RoleId });
                  j.ToTable("UserRoles");
                   });
        }
    }
}

