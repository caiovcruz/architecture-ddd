using ArchitectureDDD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchitectureDDD.Infra.Data
{
    public class UserMap : BaseMap<User>
    {
        public override void ConfigureProperties(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(80).IsRequired();
            builder.Property(p => p.UserName).HasMaxLength(100).IsRequired();
        }
    }
}
