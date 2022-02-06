using ContactsWebApp.BLL.Repository;
using ContactsWebApp.BLL.Services;
using ContactsWebApp.Shared.Entities;
using Moq;
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
            var contact = GetContact();
            var userId = 1;
            _mockRepo.Setup(x => x.Contact.CreateNewContact(contact));

            await _contactService.CreateNewContactAsync(userId, contact);

            _mockRepo.Verify(x => x.Contact.CreateNewContact(contact), Times.Exactly(1));
        }

        [Fact]
        public async void DeleteContactAsync_CallsDeleteMethodOneTime()
        {
            var contact = GetContact();
            _mockRepo.Setup(x => x.Contact.DeleteContact(contact));

            await _contactService.DeleteContactAsync(contact);

            _mockRepo.Verify(x => x.Contact.DeleteContact(contact), Times.Exactly(1));
        }

        [Fact]
        public async void UpdateContactAsync_CallsUpdateMethodOneTime()
        {
            var id = 1;
            var userId = 1;
            var contact = GetContact();
            _mockRepo.Setup(x => x.Contact.UpdateContact(contact));

            await _contactService.UpdateContactAsync(id, userId, contact);

            _mockRepo.Verify(x => x.Contact.UpdateContact(contact), Times.Exactly(1));
        }

        private Contact GetContact()
        {
            var contact = new Contact()
            {
                Id = 1,
                FullName = "Vardenis Pavardenis",
                Email = "vardenis@email.com",
                PhoneNumber = "123456789"
            };
            return contact;
        }
    }
}
