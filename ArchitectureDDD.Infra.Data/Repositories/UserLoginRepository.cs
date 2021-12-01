using ArchitectureDDD.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectureDDD.Infra.Data
{
    public class UserLoginRepository : BaseRepository<User>, IUserLoginRepository
    {
        public UserLoginRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User> GetUser(UserLoginViewModel viewModel)
        {
            return await _context.Set<User>().Where(
                x => x.UserName == viewModel.UserName &&
                     x.Password == viewModel.Password)
                .FirstOrDefaultAsync();
        }
    }
}
