using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsWebApp.BLL.Interfaces
{
    public interface IContactService
    {
        Task CreateNewContactAsync(int userId, Contact contact);
        Task<IEnumerable<Contact>> FindContactsByUserIdAsync(int userId);
        Task<Contact> FindContactByIdAsync(int id);
        Task UpdateContactAsync(int id, int userId, Contact contact);
        Task DeleteContactAsync(Contact contact);
        Task<bool> ContactExistsAsync(int id);
    }
}
