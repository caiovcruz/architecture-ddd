using ArchitectureDDD.Domain;

namespace ArchitectureDDD.Infra.Data
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context) { }
    }
}
