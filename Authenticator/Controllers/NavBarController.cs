using Authenticator.Application.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers
{

    [ApiController] // Add this to specify that it's an API controller
    public class NavBarController : Controller
    {

        private readonly IButtonBasedOnUserRoleService _buttonBasedOnUserRoleService;
        public NavBarController(IButtonBasedOnUserRoleService buttonBasedOnUserRoleService)
        {
            _buttonBasedOnUserRoleService = buttonBasedOnUserRoleService;
        }

        [HttpGet("newRequest")]
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
            return Ok(new { message = "Reports is Working" });
        }

        [HttpGet("manageAccountDetails")]
        public ActionResult getManageAccountDetails()
        {
            return Ok(new { message = "Manage Account Details is Working" });
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
