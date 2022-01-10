using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;
using System.Linq;

namespace ContactsWebApp.DAL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateNewUser(User user)
        {
            Create(user);
        }

        public User FindUserByEmail(string email)
        {
            return FindByCondition(x => x.Email.Equals(email)).SingleOrDefault();
        }

        public User FindUserByEmailAndPassword(string email, string password)
        {
            return FindByCondition(x => x.Email.Equals(email) && x.Password.Equals(password)).SingleOrDefault();
        }
    }
}
