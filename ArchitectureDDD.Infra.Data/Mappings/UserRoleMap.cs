using ArchitectureDDD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchitectureDDD.Infra.Data
{
    public class UserRoleMap : BaseMap<UserRole>
    {
        public override void ConfigureProperties(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");

            builder.Property(p => p.UserId).IsRequired();

            builder.Property(p => p.RoleId).IsRequired();
        }
    }
}
