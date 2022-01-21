using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApp.DAL.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateNewContact(Contact contact)
        {
            Create(contact);
        }

        public void DeleteContact(Contact contact)
        {
            Delete(contact);
        }

        public async Task<Contact> FindContactByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> FindContactsByUserIdAsync(int userId)
        {
            return await FindByCondition(x => x.UserId.Equals(userId)).ToListAsync();
        }

        public void UpdateContact(Contact contact)
        {
            Update(contact);
        }
    }
}
