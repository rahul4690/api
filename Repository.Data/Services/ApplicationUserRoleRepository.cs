using Repository.Data.Context;
using Repository.Data.Services.IServices;
using Repository.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.Services
{
    public class ApplicationUserRoleRepository : DataAccess<ApplicationUserRole>, IApplicationUserRoleRepository
    {
        public ApplicationUserRoleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
