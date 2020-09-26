using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.Services.IServices
{
    public interface IRepositoryWrapper
    {
        IApplicationUserRepository userRepository { get; }
        IApplicationUserRoleRepository roleRepository { get; }

        void Save();
    }
}
