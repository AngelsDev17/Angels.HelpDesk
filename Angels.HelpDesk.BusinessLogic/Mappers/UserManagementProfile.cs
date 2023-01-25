using Angels.HelpDesk.Application.Dtos.UserManagement;
using AutoMapper;
using UserDb = Angels.HelpDesk.Domain.Models.UserManagement;

namespace Angels.HelpDesk.BusinessLogic.Mappers
{
    public class UserManagementProfile : Profile
    {
        public UserManagementProfile()
        {
            AllowNullCollections = true;

            CreateMap<BasicUserInfo, UserDb.User>()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForPath(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
                .ForPath(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<UserInfoToUpdate, UserDb.User>()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForPath(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
                .ForPath(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        }
    }
}
