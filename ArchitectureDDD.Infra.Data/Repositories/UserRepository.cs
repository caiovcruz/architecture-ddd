using ArchitectureDDD.Domain;

namespace ArchitectureDDD.Infra.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
