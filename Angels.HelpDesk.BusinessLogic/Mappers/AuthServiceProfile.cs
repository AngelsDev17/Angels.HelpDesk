using Angels.HelpDesk.Application.Commons;
using Angels.HelpDesk.Application.Dtos.AuthService;
using Angels.HelpDesk.Application.Dtos.UserManagement;
using AutoMapper;
using CommonsDb = Angels.HelpDesk.Domain.Commons;
using UserDb = Angels.HelpDesk.Domain.Models.UserManagement;

namespace Angels.HelpDesk.BusinessLogic.Mappers
{
    public class AuthServiceProfile : Profile
    {
        public AuthServiceProfile()
        {
            AllowNullCollections = true;

            CreateMap<ReferencedValue, CommonsDb.ReferencedValue>()
                .ReverseMap();

            CreateMap<Identification, UserDb.Identification>()
                .ReverseMap();

            CreateMap<UserDb.User, BasicUserInfo>();

            CreateMap<UserInfoToRegister, UserDb.User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForPath(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
                .ForPath(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<UserInfoToRegister, BasicUserInfo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
