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
            CreateMap<ApplicationUserVM, ApplicationUserModel>();
            CreateMap<ApplicationUserModel, ApplicationUserVM>();

            CreateMap<ApplicationUserRolesVM, ApplicationUserRoleModel>();
            CreateMap<ApplicationUserRoleModel, ApplicationUserRolesVM>();

            CreateMap<CategoryModel, CategoryVM>();
            CreateMap<CategoryVM, CategoryModel>();
        }
    }
}
