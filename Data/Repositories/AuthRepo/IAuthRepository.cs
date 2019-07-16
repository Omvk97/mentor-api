using System.Threading.Tasks;
using mentor_api.Models;

namespace mentor_api.Data.Repositories.AuthRepo
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<bool> UserIsMentor(int userId);

    }
}