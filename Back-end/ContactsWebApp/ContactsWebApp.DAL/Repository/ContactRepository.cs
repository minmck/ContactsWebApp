using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public Contact FindContactById(int id)
        {
            return FindByCondition(x => x.Id.Equals(id)).SingleOrDefault();
        }

        public IEnumerable<Contact> FindContactsByUserId(int userId)
        {
            return FindByCondition(x => x.UserId.Equals(userId));
        }

        public void UpdateContact(Contact contact)
        {
            Update(contact);
        }
    }
}
