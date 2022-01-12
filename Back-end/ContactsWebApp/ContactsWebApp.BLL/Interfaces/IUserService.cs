using ContactsWebApp.Shared.Entities;

namespace ContactsWebApp.BLL.Interfaces
{
    public interface IUserService
    {
        bool UserExists(string email);
        void CreateNewUser(User user);
        bool UserValid(string email, string password);
        User FindUserByEmail(string email);
    }
}
