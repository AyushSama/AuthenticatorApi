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

        public UserAuthenticatorController(IUserAuthenticatorService userAuthenticatorService) 
        {
            _userAuthenticatorService = userAuthenticatorService;
        }

        [HttpGet("getUser")]
        public ActionResult<UserAuthenticator> GetUser(string email, string password) 
        { 
            var res =  _userAuthenticatorService.getUser(email, password);
            if (res == null) 
            {
                return NotFound();
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
