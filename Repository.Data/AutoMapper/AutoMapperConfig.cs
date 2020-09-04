using AutoMapper;
using Repository.Models.Models;
using Repository.Models.ViewModels;

namespace Repository.Data.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            Mapping();
        }

        void Mapping()
        {
            CreateMap<ApplicationUserVM, ApplicationUser>();
            CreateMap<ApplicationUserRolesVM, ApplicationUserRole>();
        }
    }
}
