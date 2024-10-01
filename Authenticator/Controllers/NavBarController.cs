using Authenticator.Application.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers
{

    [ApiController] // Add this to specify that it's an API controller
    public class NavBarController : Controller
    {

        private readonly IButtonBasedOnUserRoleService _buttonBasedOnUserRoleService;
        private readonly IButtonTableService _buttonTableService;
        public NavBarController(IButtonBasedOnUserRoleService buttonBasedOnUserRoleService, IButtonTableService buttonTableService)
        {
            _buttonBasedOnUserRoleService = buttonBasedOnUserRoleService;
            _buttonTableService = buttonTableService;
        }

        [HttpGet("newRequests")]
        public ActionResult getNewRequests()
        {
            return Ok(new { message = "New Request is Working" });
        }

        [HttpGet("premiumServices")]
        public ActionResult getPremiumServices()
        {
            return Ok(new { message = "Premium Services is Working" });
        }

        [HttpGet("delete")]
        public ActionResult getDelete()
        {
            return Ok(new { message = "Delete is Working" });
        }

        [HttpGet("reports")]
        public ActionResult getReports()
        {
            var list = _buttonTableService.getButtonNames("Reports");
            return Ok(new { button = list, message = "Reports is Working" });
        }

        [HttpGet("manageAccountDetails")]
        public ActionResult getManageAccountDetails()
        {
            var list = _buttonTableService.getButtonNames("Manage Account Details");
            return Ok(new { button = list, message = "Manage Account Details is Working" });
        }

        [HttpGet("loginPageText")]
        public ActionResult getLoginPageText()
        {
            return Ok(new { message = "Login Page Text is Working" });
        }

        [HttpGet("getNavButtons")]
        public ActionResult getNavButtons()
        {
            var res = _buttonBasedOnUserRoleService.getButtons("admin");
            return Ok(res);
        }

    }
}
