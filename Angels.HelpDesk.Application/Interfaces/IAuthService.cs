using Angels.HelpDesk.Application.Dtos.AuthService;

namespace Angels.HelpDesk.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> SignInUser(AuthUser authUser);
        Task<string> RegisterUser(UserInfoToRegister userInfoToRegister);
    }
}
