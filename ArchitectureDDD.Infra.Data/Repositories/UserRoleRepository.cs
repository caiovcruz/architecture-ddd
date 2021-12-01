using ArchitectureDDD.Domain;

namespace ArchitectureDDD.Infra.Data
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context) { }
    }
}
