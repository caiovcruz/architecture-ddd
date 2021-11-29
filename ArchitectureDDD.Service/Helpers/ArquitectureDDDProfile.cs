using ArchitectureDDD.Domain;
using AutoMapper;

namespace ArchitectureDDD.Service.Helpers
{
    public class ArchitectureDDDProfile : Profile
    {
        public ArchitectureDDDProfile()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<RoleViewModel, Role>().ReverseMap();
            CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
        }
    }
}