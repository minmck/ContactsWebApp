using ContactsWebApp.Shared.Entities;
using System.Threading.Tasks;

namespace ContactsWebApp.BLL.Repository
{
    public interface IUserRepository
    {
        Task<User> FindUserByEmailAsync(string email);
        Task<User> FindUserByEmailAndPasswordAsync(string email, string password);
        void CreateNewUser(User user);
    }
}
