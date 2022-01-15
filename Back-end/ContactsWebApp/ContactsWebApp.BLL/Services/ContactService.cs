using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;

namespace ContactsWebApp.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateNewContact(int userId, Contact contact)
        {
            contact.UserId = userId;
            _unitOfWork.Contact.CreateNewContact(contact);
            _unitOfWork.Save();
        }

        public void DeleteContact(Contact contact)
        {
            _unitOfWork.Contact.DeleteContact(contact);
            _unitOfWork.Save();
        }

        public IEnumerable<Contact> FindContactsByUserId(int userId)
        {
            return _unitOfWork.Contact.FindContactsByUserId(userId);
        }

        public void UpdateContact(Contact contact)
        {
            _unitOfWork.Contact.UpdateContact(contact);
            _unitOfWork.Save();
        }

        public bool ContactsExist(int userId)
        {
            var contacts = _unitOfWork.Contact.FindContactsByUserId(userId);

            if (contacts != null) return true;

            return false;
        }

        public bool ContactExists(int id)
        {
            var contact = _unitOfWork.Contact.FindContactById(id);

            if (contact != null) return true;

            return false;
        }

        public Contact FindContactById(int id)
        {
            return _unitOfWork.Contact.FindContactById(id);
        }
    }
}
