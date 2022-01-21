using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.BLL.Repository;
using ContactsWebApp.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsWebApp.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateNewContactAsync(int userId, Contact contact)
        {
            contact.UserId = userId;
            _unitOfWork.Contact.CreateNewContact(contact);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            _unitOfWork.Contact.DeleteContact(contact);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Contact>> FindContactsByUserIdAsync(int userId)
        {
            return await _unitOfWork.Contact.FindContactsByUserIdAsync(userId);
        }

        public async Task UpdateContactAsync(int id, int userId, Contact contact)
        {
            contact.Id = id;
            contact.UserId = userId;
            _unitOfWork.Contact.UpdateContact(contact);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> ContactsExistAsync(int userId)
        {
            var contacts = await _unitOfWork.Contact.FindContactsByUserIdAsync(userId);

            if (contacts != null) return true;

            return false;
        }

        public async Task<bool> ContactExistsAsync(int id)
        {
            var contact = await _unitOfWork.Contact.FindContactByIdAsync(id);

            if (contact != null) return true;

            return false;
        }

        public async Task<Contact> FindContactByIdAsync(int id)
        {
            return await _unitOfWork.Contact.FindContactByIdAsync(id);
        }
    }
}
