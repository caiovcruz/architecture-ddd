using ArchitectureDDD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchitectureDDD.Infra.Data
{
    public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(p => p.UpdateDate).IsRequired(false);
            builder.Property(p => p.Active).IsRequired();
            builder.Property(p => p.AuditUser).IsRequired(false);

            ConfigureProperties(builder);
        }

        public abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
    }
}
