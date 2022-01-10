using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;

namespace ContactsWebApp.BLL.Repository
{
    public interface IContactRepository
    {
        void CreateNewContact(Contact contact);
        IEnumerable<Contact> FindContactsByUserId(int userId);
        Contact FindContactById(int id);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
