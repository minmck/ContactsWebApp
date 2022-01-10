using ContactsWebApp.BLL.Repository;

namespace ContactsWebApp.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository _userRepository;
        private IContactRepository _contactRepository;

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);

                return _userRepository;
            }
        }

        public IContactRepository Contact
        {
            get
            {
                if (_contactRepository == null)
                    _contactRepository = new ContactRepository(_repositoryContext);

                return _contactRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
