using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core.DBEntities;
using Authenticator.CustomActionFilters;
using ConfigReader.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {

        private readonly IAdminMasterUserService _adminMasterUserService;
        private readonly IActivatorMenuMasterService _activatorMenuMasterService;
        
        public LoginController(IAdminMasterUserService adminMasterUserService, IActivatorMenuMasterService activatorMenuMasterService)
        {
            _adminMasterUserService = adminMasterUserService;
            _activatorMenuMasterService = activatorMenuMasterService;
        }

        [HttpGet("login")]
        [ServiceFilter(typeof(Authenticate))] // Apply the custom Authenticate filter
        public ActionResult<AdminMasterUser> CheckUser(string username, string password)
        {
            // Since the authentication logic is handled in the filter,
            // you can just return the authenticated user here if needed.

            // Assuming the user information is set in the HttpContext after successful authentication
            var user = HttpContext.Items["AuthenticatedUser"] as AdminMasterUser;
            var token = HttpContext.Items["token"];

            if (user != null)
            {
                return Ok(new { token, user});
            }

            return Unauthorized();
        }

        [HttpGet("getMenu")]
        public ActionResult GetMenu(int parentId)
        {
            Message message = new Message();
            var res = _activatorMenuMasterService.GetMenu(parentId,message);
            if (res != null) 
            {
                return Ok(res);
            }
            return NotFound();
        }
    }
}
