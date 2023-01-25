using Angels.HelpDesk.Application.Commons;
using Angels.HelpDesk.Application.Dtos.UserManagement;

namespace Angels.HelpDesk.Application.Interfaces
{
    public interface IUserManagementService
    {
        Task<DatatableData> GetAllUsersForTheDatatable();

        Task<BasicUserInfo> GetBasicUserInformation(string userId);
        Task ChangeStatusForTheUser(StatusChange statusChange);
        Task UpdateUser(UserInfoToUpdate basicUser);
        Task DeleteUser(string userId);
    }
}
