using System.Threading.Tasks;

namespace ArchitectureDDD.Domain
{
    public interface IUserLoginService
    {
        Task<User> Login(UserLoginViewModel viewModel);
    }
}
