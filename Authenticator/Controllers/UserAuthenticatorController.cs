using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.BusinessServices;
using Authenticator.Core.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers
{
    [ApiController] // Add this to specify that it's an API controller
    [Route("api/[controller]")] // Route convention for API controllers
    public class UserAuthenticatorController : Controller
    {
        private readonly IUserAuthenticatorService _userAuthenticatorService;
        private readonly ILoginHistoryAuthenticatorService _loginHistoryAuthenticatorService;

        public UserAuthenticatorController(IUserAuthenticatorService userAuthenticatorService, ILoginHistoryAuthenticatorService loginHistoryAuthenticator) 
        {
            _userAuthenticatorService = userAuthenticatorService;
            _loginHistoryAuthenticatorService = loginHistoryAuthenticator;
        }

        [HttpGet("getUser")]
        public ActionResult<UserAuthenticator> GetUser(string email, string password) 
        {   
            string requestIP = HttpContext.Connection.RemoteIpAddress?.ToString();
            var res =  _userAuthenticatorService.getUser(email, password);
            if (res == null) 
            {
                return NotFound();
            }
            else
            {
                LoginHistoryAuthenticator loginHistoryAuthenticator = new LoginHistoryAuthenticator()
                {   
                    userId = res.userId,
                    requestIP = requestIP,
                    status = true,
                    timestamp = DateTime.UtcNow,
                };
                _loginHistoryAuthenticatorService.Log(loginHistoryAuthenticator);
            }
            return Ok(res);
        }

        [HttpPost("postUser")]
        public ActionResult PostUser([FromBody] UserAuthenticator userAuthenticator)
        {
            _userAuthenticatorService.postUser(userAuthenticator);
            return Ok("User Added Successfully");
        }

    }
}
