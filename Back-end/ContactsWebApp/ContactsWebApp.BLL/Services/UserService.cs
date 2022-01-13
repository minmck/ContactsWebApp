using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;

namespace ContactsWebApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool UserExists(string email)
        {
            var user = FindUserByEmail(email);

            if (user != null) return true;

            return false;
        }

        public void CreateNewUser(User user)
        {
            _unitOfWork.User.CreateNewUser(user);
            _unitOfWork.Save();
        }

        public bool UserValid(string email, string password)
        {
            var user = _unitOfWork.User.FindUserByEmailAndPassword(email, password);

            if (user != null) return true;

            return false;
        }

        public User FindUserByEmail(string email)
        {
            return _unitOfWork.User.FindUserByEmail(email);
        }
    }
}