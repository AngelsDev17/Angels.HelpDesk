using Angels.HelpDesk.Domain.Enums;
using Angels.HelpDesk.Domain.Interfaces.Commons;
using Angels.HelpDesk.Domain.Models.UserManagement;

namespace Angels.HelpDesk.Domain.Interfaces.Models.AuthService
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindOneByEmailAndStatus(string email, Status status = Status.Active);
        Task<long> CountByEmailOrIdentification(string email, string identification);

        Task<List<User>> FindAllByStatus(Status status = Status.Active);
        Task<User> FindOneByIdAndStatus(string id, Status status = Status.Active);
        Task ChangeStatusByIdAndStatus(string userId, Status status);
        Task UpdateUserData(User user, Status status = Status.Active);
        Task DeleteUserByIdAndStatus(string userId, Status status = Status.Inactive);
    }
}
