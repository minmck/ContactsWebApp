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

        public void CreateNewContact(Contact contact)
        {
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

        public void UpdateContact(int userId, int id, Contact contact)
        {
            contact.UserId = userId;
            contact.Id = id;
            _unitOfWork.Contact.UpdateContact(contact);
            _unitOfWork.Save();
        }
    }
}
