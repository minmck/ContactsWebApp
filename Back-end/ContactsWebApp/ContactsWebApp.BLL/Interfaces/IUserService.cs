using ContactsWebApp.Shared.Entities;
using System.Threading.Tasks;

namespace ContactsWebApp.BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string email);
        Task CreateNewUserAsync(User user);
        Task<bool> UserValidAsync(string email, string password);
        Task<User> FindUserByEmailAsync(string email);
    }
}
