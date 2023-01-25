using Angels.HelpDesk.Application.Dtos.AuthService;
using Angels.HelpDesk.Application.Interfaces;
using Angels.HelpDesk.BusinessLogic.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace Angels.HelpDesk.WebApi.Controllers
{
    [ApiController]
    [Route("auth-service")]
    public class AuthServiceController : ControllerBase
    {
        private readonly ILogger<AuthServiceController> _logger;
        private readonly IAuthService _authService;

        public AuthServiceController(
            ILogger<AuthServiceController> logger,
            IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }


        [HttpPost("signin-user")]
        public async Task<IActionResult> SignInUser(AuthUser authUser)
        {
            _logger.LogDebugInMethod("Controller: " + nameof(SignInUser));

            try
            {
                var response = await _authService.SignInUser(authUser);
                return Ok(response);
            }
            catch (TimeoutException ex)
            {
                return base.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error: " + ex.Message);
                return base.BadRequest(ex.Message);
            }
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(UserInfoToRegister userInfoToRegister)
        {
            _logger.LogDebugInMethod("Controller: " + nameof(RegisterUser));

            try
            {
                var response = await _authService.RegisterUser(userInfoToRegister);
                return Ok(response);
            }
            catch (TimeoutException ex)
            {
                return base.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error: " + ex.Message);
                return base.BadRequest(ex.Message);
            }
        }
    }
}
