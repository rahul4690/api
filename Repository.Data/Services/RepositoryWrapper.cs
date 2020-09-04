using Repository.Data.Context;
using Repository.Data.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public void Save()
        {
            _applicationDbContext.SaveChangesAsync();
        }
    }
}
