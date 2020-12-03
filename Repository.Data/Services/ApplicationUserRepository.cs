using AutoMapper;
using Repository.Data.Context;
using Repository.Data.Services.IServices;
using Repository.Models.Models;

namespace Repository.Data.Services
{
    public class ApplicationUserRepository : DataAccess<ApplicationUserModel>, IApplicationUserRepository
    {
      
        public ApplicationUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
           
        }

    }
}
