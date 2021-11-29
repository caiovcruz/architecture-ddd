using ArchitectureDDD.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureDDD.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Role>(new RoleMap().Configure);
            modelBuilder.Entity<UserRole>(new UserRoleMap().Configure);
        }
    }
}
