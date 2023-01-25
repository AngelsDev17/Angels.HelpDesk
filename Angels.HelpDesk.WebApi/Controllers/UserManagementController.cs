using Angels.HelpDesk.Application.Dtos.UserManagement;
using Angels.HelpDesk.Application.Interfaces;
using Angels.HelpDesk.BusinessLogic.ExtensionMethods;
using Angels.HelpDesk.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Angels.HelpDesk.WebApi.Controllers
{
    [Route("user-management")]
    [ApiController]
    [Authorize]
    public class UserManagementController : ControllerBase
    {
        private readonly ILogger<UserManagementController> _logger;
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(
            ILogger<UserManagementController> logger,
            IUserManagementService userManagementService)
        {
            _logger = logger;
            _userManagementService = userManagementService;
        }


        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogDebugInMethod("Controller: " + nameof(GetAllUsers));

            try
            {
                var response = await _userManagementService.GetAllUsersForTheDatatable();
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

        [HttpGet("get-personal-user-information")]
        public async Task<IActionResult> GetPersonalUserInformation()
        {
            _logger.LogDebugInMethod("Controller: " + nameof(GetBasicUserInformation));

            try
            {
                var userId = Request.GetUserIdFromBearerToken();

                var response = await _userManagementService.GetBasicUserInformation(userId);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return base.BadRequest(ex.Message);
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

        [HttpPost("get-basic-user-information")]
        public async Task<IActionResult> GetBasicUserInformation(string userId)
        {
            _logger.LogDebugInMethod("Controller: " + nameof(GetBasicUserInformation));

            try
            {
                var response = await _userManagementService.GetBasicUserInformation(userId);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return base.BadRequest(ex.Message);
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

        [HttpPost("change-status-for-user")]
        public async Task<IActionResult> ChangeStatusForTheUser(StatusChange statusChange)
        {
            _logger.LogDebugInMethod("Controller: " + nameof(ChangeStatusForTheUser));

            try
            {
                await _userManagementService.ChangeStatusForTheUser(statusChange);
                return Ok();
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

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(UserInfoToUpdate basicUser)
        {
            _logger.LogDebugInMethod("Controller: " + nameof(UpdateUser));

            try
            {
                await _userManagementService.UpdateUser(basicUser);
                return Ok();
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

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            _logger.LogDebugInMethod("Controller: " + nameof(DeleteUser));

            try
            {
                await _userManagementService.DeleteUser(userId);
                return Ok();
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
