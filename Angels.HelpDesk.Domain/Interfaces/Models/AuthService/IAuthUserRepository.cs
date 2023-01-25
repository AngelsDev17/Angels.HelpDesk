using Angels.HelpDesk.Domain.Enums;
using Angels.HelpDesk.Domain.Interfaces.Commons;
using Angels.HelpDesk.Domain.Models.AuthService;

namespace Angels.HelpDesk.Domain.Interfaces.Models.AuthService
{
    public interface IAuthUserRepository : IBaseRepository<AuthUser>
    {
        Task<AuthUser> FindOneByEmailAndStatus(string email, Status status = Status.Active);
    }
}
