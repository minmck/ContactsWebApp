using ContactsWebApp.BLL.Repository;
using ContactsWebApp.BLL.Services;
using ContactsWebApp.Shared.Entities;
using Moq;
using Xunit;

namespace ContactsWebApp.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockRepo = new Mock<IUnitOfWork>();
            _userService = new UserService(_mockRepo.Object);
        }

        [Fact]
        public async void UserExistsAsync_UserExists_ReturnsTrue()
        {
            var user = GetUser();
            var email = "email@email.com";
            _mockRepo.Setup(x => x.User.FindUserByEmailAsync(email))
                .ReturnsAsync(user);

            var actual = await _userService.UserExistsAsync(email);

            Assert.True(actual);
        }

        [Fact]
        public async void UserExistsAsync_UserDoesNotExist_ReturnsFalse()
        {
            User user = null;
            var email = "email@email.com";
            _mockRepo.Setup(x => x.User.FindUserByEmailAsync(email))
                .ReturnsAsync(user);

            var actual = await _userService.UserExistsAsync(email);

            Assert.False(actual);
        }

        [Fact]
        public async void CreateNewUserAsync_CallsCreateMethodOneTime()
        {
            var user = GetUser();
            _mockRepo.Setup(x => x.User.CreateNewUser(user));

            await _userService.CreateNewUserAsync(user);

            _mockRepo.Verify(x => x.User.CreateNewUser(user), Times.Exactly(1));
        }

        [Fact]
        public async void UserValidAsync_UserExists_ReturnsTrue()
        {
            var user = GetUser();
            var email = "email@email.com";
            var password = "password";
            _mockRepo.Setup(x => x.User.FindUserByEmailAndPasswordAsync(email, password))
                .ReturnsAsync(user);

            var actual = await _userService.UserValidAsync(email, password);

            Assert.True(actual);
        }

        [Fact]
        public async void UserValidAsync_UserDoesNotExist_ReturnsFalse()
        {
            User user = null;
            var email = "email@email.com";
            var password = "password";
            _mockRepo.Setup(x => x.User.FindUserByEmailAndPasswordAsync(email, password))
                 .ReturnsAsync(user);

            var actual = await _userService.UserValidAsync(email, password);

            Assert.False(actual);
        }

        [Fact]
        public async void FindUserByEmailAsync_ReturnsUser()
        {
            var email = "email@email.com";
            var user = GetUser();
            _mockRepo.Setup(x => x.User.FindUserByEmailAsync(email))
                .ReturnsAsync(user);

            var expected = GetUser();
            var actual = await _userService.FindUserByEmailAsync(email);

            Assert.True(actual != null);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
        }

        private User GetUser()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john@email.com",
                Password = "password"
            };
            return user;
        }
    }
}
