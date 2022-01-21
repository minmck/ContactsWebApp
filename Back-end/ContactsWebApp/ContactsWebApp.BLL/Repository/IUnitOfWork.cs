using System.Threading.Tasks;

namespace ContactsWebApp.BLL.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IContactRepository Contact { get; }
        Task SaveAsync();
    }
}
