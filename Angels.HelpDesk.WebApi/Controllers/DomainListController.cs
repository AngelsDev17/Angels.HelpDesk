using Angels.HelpDesk.Application.Interfaces;
using Angels.HelpDesk.BusinessLogic.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Angels.HelpDesk.WebApi.Controllers
{
    [Route("help-desk")]
    [ApiController]
    [Authorize]
    public class DomainListController : ControllerBase
    {
        private readonly ILogger<DomainListController> _logger;
        private readonly IDomainListService _domainListService;

        public DomainListController(
            ILogger<DomainListController> logger,
            IDomainListService domainListService)
        {
            _logger = logger;
            _domainListService = domainListService;
        }


        [HttpGet("get-identification-type")]
        public async Task<IActionResult> GetIdentificationTypeList()
        {
            _logger.LogDebugInMethod("Controller: " + nameof(GetIdentificationTypeList));

            try
            {
                var response = await _domainListService.GetIdentificationTypeList();
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

        [HttpGet("get-category")]
        public async Task<IActionResult> GetCategoryList()
        {
            _logger.LogDebugInMethod("Controller: " + nameof(GetCategoryList));

            try
            {
                var response = await _domainListService.GetCategoryList();
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

        [HttpGet("get-role")]
        public async Task<IActionResult> GetRoleList()
        {
            _logger.LogDebugInMethod("Controller: " + nameof(GetRoleList));

            try
            {
                var response = await _domainListService.GetRoleList();
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
