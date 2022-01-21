using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsWebApp.BLL.Repository
{
    public interface IContactRepository
    {
        void CreateNewContact(Contact contact);
        Task<IEnumerable<Contact>> FindContactsByUserIdAsync(int userId);
        Task<Contact> FindContactByIdAsync(int id);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
