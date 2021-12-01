using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchitectureDDD.Domain
{
    public interface IUserLoginRepository
    {
        Task<User> GetUser(UserLoginViewModel viewModel);
    }
}
