using Repository.Data.Context;
using Repository.Data.Services.IServices;

namespace Repository.Data.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext _applicationDbContext;
        private IApplicationUserRepository _applicationUserRepository;
        private IApplicationUserRoleRepository _applicationUserRoleRepository;
        private ICategoryRepository _categoryRepository;
        private IOtpRepository _otpRepository;

        public IApplicationUserRepository userRepository
        {
            get
            {
                if(_applicationUserRepository == null)
                {
                    _applicationUserRepository = new ApplicationUserRepository(_applicationDbContext);
                }
                return _applicationUserRepository;
            }
        }

        public IApplicationUserRoleRepository roleRepository
        {
            get
            {
                if (_applicationUserRoleRepository == null)
                {
                    _applicationUserRoleRepository = new ApplicationUserRoleRepository(_applicationDbContext);
                }
                return _applicationUserRoleRepository;
            }
        }

        public ICategoryRepository categoryRepository
        {
            get
            {
                if(_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_applicationDbContext);
                }
                return _categoryRepository;
            }
        }

        public IOtpRepository otpRepository
        {
            get
            {
                if (_otpRepository == null)
                {
                    _otpRepository = new OtpRepository(_applicationDbContext);
                }
                return _otpRepository;
            }
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
