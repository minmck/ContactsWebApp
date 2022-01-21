using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await FindByCondition(x => x.Email.Equals(email)).SingleOrDefaultAsync();
        }

        public async Task<User> FindUserByEmailAndPasswordAsync(string email, string password)
        {
            return await FindByCondition(x => x.Email.Equals(email) && x.Password.Equals(password)).SingleOrDefaultAsync();
        }
    }
}
