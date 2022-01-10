using ContactsWebApp.Shared.Entities;

namespace ContactsWebApp.BLL.Repository
{
    public interface IUserRepository
    {
        User FindUserByEmail(string email);
        User FindUserByEmailAndPassword(string email, string password);
        void CreateNewUser(User user);
    }
}
