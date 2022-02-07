using ContactsWebApp.BLL.Repository;
using ContactsWebApp.BLL.Services;
using ContactsWebApp.Shared.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ContactsWebApp.Tests
{
    public class ContactServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly ContactService _contactService;

        public ContactServiceTests()
        {
            _mockRepo = new Mock<IUnitOfWork>();
            _contactService = new ContactService(_mockRepo.Object);
        }

        [Fact]
        public async void CreateNewContactAsync_CallsCreateMethodOneTime()
        {
            var contact = GetContacts()[0];
            var userId = 1;
            _mockRepo.Setup(x => x.Contact.CreateNewContact(contact));

            await _contactService.CreateNewContactAsync(userId, contact);

            _mockRepo.Verify(x => x.Contact.CreateNewContact(contact), Times.Exactly(1));
        }

        [Fact]
        public async void DeleteContactAsync_CallsDeleteMethodOneTime()
        {
            var contact = GetContacts()[0];
            _mockRepo.Setup(x => x.Contact.DeleteContact(contact));

            await _contactService.DeleteContactAsync(contact);

            _mockRepo.Verify(x => x.Contact.DeleteContact(contact), Times.Exactly(1));
        }

        [Fact]
        public async void UpdateContactAsync_CallsUpdateMethodOneTime()
        {
            var id = 1;
            var userId = 1;
            var contact = GetContacts()[0];
            _mockRepo.Setup(x => x.Contact.UpdateContact(contact));

            await _contactService.UpdateContactAsync(id, userId, contact);

            _mockRepo.Verify(x => x.Contact.UpdateContact(contact), Times.Exactly(1));
        }

        [Fact]
        public async void FindContactsByUserIdAsync_ReturnsListOfContacts()
        {
            var userId = 1;
            var contacts = GetContacts();
            _mockRepo.Setup(x => x.Contact.FindContactsByUserIdAsync(userId))
                .ReturnsAsync(contacts);

            var actual = await _contactService.FindContactsByUserIdAsync(userId);

            Assert.True(contacts.Count == actual.Count());
            Assert.Equal(contacts, actual);
        }

        [Fact]
        public async void ContactExistsAsync_ContactExists_ReturnsTrue()
        {
            var id = 1;
            var contact = GetContacts()[0];
            _mockRepo.Setup(x => x.Contact.FindContactByIdAsync(id))
                .ReturnsAsync(contact);

            var actual = await _contactService.ContactExistsAsync(id);

            Assert.True(actual);
        }

        [Fact]
        public async void ContactExistsAsync_ContactDoesNotExist_ReturnsFalse()
        {
            var id = 1;
            Contact contact = null;
            _mockRepo.Setup(x => x.Contact.FindContactByIdAsync(id))
                .ReturnsAsync(contact);

            var actual = await _contactService.ContactExistsAsync(id);

            Assert.False(actual);
        }

        [Fact]
        public async void FindContactByIdAsync_ReturnsContact()
        {
            var id = 1;
            var contact = GetContacts()[0];
            _mockRepo.Setup(x => x.Contact.FindContactByIdAsync(id))
                .ReturnsAsync(contact);

            var actual = await _contactService.FindContactByIdAsync(id);

            Assert.Equal(contact, actual);
        }

        private List<Contact> GetContacts()
        {
            var contacts = new List<Contact>()
            {
                new Contact
                {
                    Id = 1,
                    FullName = "Vardenis Pavardenis",
                    Email = "vardenis@email.com",
                    PhoneNumber = "123456789"
                },
                new Contact
                {
                    Id = 2,
                    FullName = "John Smith",
                    Email = "john@email.com",
                    PhoneNumber = "987654321"
                }
        };
            return contacts;
        }
    }
}