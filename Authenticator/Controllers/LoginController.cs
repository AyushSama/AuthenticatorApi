using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core.DBEntities;
using ConfigReader.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {

        public IAdminMasterUserService _adminMasterUserService;
        public LoginController(IAdminMasterUserService adminMasterUserService)
        {
            _adminMasterUserService = adminMasterUserService;
        }

        [HttpGet("login")]
        public AdminMasterUser checkUser(string username,string password)
        {   
            Message message = new Message();
            AdminMasterUser check = _adminMasterUserService.authenticateUser(username, password,message);
            return check;
        }
    }
}
