using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;

namespace ContactsWebApp.BLL.Interfaces
{
    public interface IContactService
    {
        void CreateNewContact(int userId, Contact contact);
        IEnumerable<Contact> FindContactsByUserId(int userId);
        Contact FindContactById(int id);
        void UpdateContact(int id, int userId, Contact contact);
        void DeleteContact(Contact contact);
        bool ContactsExist(int userId);
        bool ContactExists(int id);
    }
}
