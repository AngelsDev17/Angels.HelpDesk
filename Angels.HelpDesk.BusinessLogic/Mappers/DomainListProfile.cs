using Angels.HelpDesk.Application.Commons;
using Angels.HelpDesk.Domain.Models.DomainLists;
using AutoMapper;

namespace Angels.HelpDesk.BusinessLogic.Mappers
{
    public class DomainListProfile : Profile
    {
        public DomainListProfile()
        {
            AllowNullCollections = true;

            CreateMap<IdentificationType, ReferencedValue>();
            CreateMap<Category, ReferencedValue>();
            CreateMap<Role, ReferencedValue>();
        }
    }
}
