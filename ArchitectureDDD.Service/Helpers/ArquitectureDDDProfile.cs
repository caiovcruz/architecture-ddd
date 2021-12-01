using ArchitectureDDD.Domain;
using AutoMapper;

namespace ArchitectureDDD.Service
{
    public class ArchitectureDDDProfile : Profile
    {
        public ArchitectureDDDProfile()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<RoleViewModel, Role>().ReverseMap();
            CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
            CreateMap<UserLoginViewModel, UserLogin>().ReverseMap();
        }
    }
}