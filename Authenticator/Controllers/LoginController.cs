using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core.DBEntities;
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
        public AdminMasterUser checkUser(string username, string password)
        {
            Message message = new Message();
            AdminMasterUser check = _adminMasterUserService.authenticateUser(username, password, message);
            return check;
        }

        [HttpGet("getMenu")]
        public ActionResult GetMenu(int parentId)
        {
            Message message = new Message();
            var res = _activatorMenuMasterService.GetMenu(parentId,message);
            return Ok(res);
        }
    }
}
