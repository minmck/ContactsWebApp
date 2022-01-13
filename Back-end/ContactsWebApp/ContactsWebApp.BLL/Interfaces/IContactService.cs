using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;

namespace ContactsWebApp.BLL.Interfaces
{
    public interface IContactService
    {
        void CreateNewContact(Contact contact);
        IEnumerable<Contact> FindContactsByUserId(int userId);
        void UpdateContact(int userId, int id, Contact contact);
        void DeleteContact(Contact contact);
    }
}
