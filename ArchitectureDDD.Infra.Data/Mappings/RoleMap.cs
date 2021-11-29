using ArchitectureDDD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchitectureDDD.Infra.Data
{
    public class RoleMap : BaseMap<Role>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
