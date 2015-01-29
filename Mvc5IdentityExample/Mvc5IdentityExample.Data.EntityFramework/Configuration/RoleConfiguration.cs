using Mvc5IdentityExample.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Mvc5IdentityExample.Data.EntityFramework.Configuration
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        internal RoleConfiguration()
        {
            ToTable("Role");

            HasKey(x => x.RoleId)
                .Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("RoleId");
                    x.MapRightKey("UserId");
                });
        }
    }
}