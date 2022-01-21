using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;
using System.Threading.Tasks;

namespace ContactsWebApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            var user = await FindUserByEmailAsync(email);

            if (user != null) return true;

            return false;
        }

        public async Task CreateNewUserAsync(User user)
        {
            _unitOfWork.User.CreateNewUser(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> UserValidAsync(string email, string password)
        {
            var user = await _unitOfWork.User.FindUserByEmailAndPasswordAsync(email, password);

            if (user != null) return true;

            return false;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _unitOfWork.User.FindUserByEmailAsync(email);
        }
    }
}