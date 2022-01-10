namespace ContactsWebApp.BLL.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IContactRepository Contact { get; }
        void Save();
    }
}
