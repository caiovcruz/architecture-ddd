using System.Threading.Tasks;

namespace ArchitectureDDD.Domain
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
