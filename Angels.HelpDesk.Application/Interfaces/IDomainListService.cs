using Angels.HelpDesk.Application.Commons;

namespace Angels.HelpDesk.Application.Interfaces
{
    public interface IDomainListService
    {
        Task<List<ReferencedValue>> GetIdentificationTypeList();
        Task<List<ReferencedValue>> GetCategoryList();
        Task<List<ReferencedValue>> GetRoleList();
    }
}
