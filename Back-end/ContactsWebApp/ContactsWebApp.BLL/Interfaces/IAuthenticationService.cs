using ContactsWebApp.Shared.Entities;

namespace ContactsWebApp.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateJwtToken(User user);
    }
}
