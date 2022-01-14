using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;

namespace ContactsWebApp.BLL.Interfaces
{
    public interface IContactService
    {
        void CreateNewContact(Contact contact);
        IEnumerable<Contact> FindContactsByUserId(int userId);
        Contact FindContactById(int id);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        bool ContactsExist(int userId);
        bool ContactExists(int id);
    }
}
