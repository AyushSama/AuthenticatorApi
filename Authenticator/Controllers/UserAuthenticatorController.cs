using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core.DBEntities;
using Authenticator.TokenHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Authenticator.Controllers
{
    [ApiController] // Add this to specify that it's an API controller
    [Route("api/[controller]")] // Route convention for API controllers
    public class UserAuthenticatorController : Controller
    {
        private readonly IUserAuthenticatorService _userAuthenticatorService;
        private readonly ILoginHistoryAuthenticatorService _loginHistoryAuthenticatorService;
        private readonly HandleToken _handleToken;

        public UserAuthenticatorController(IUserAuthenticatorService userAuthenticatorService, ILoginHistoryAuthenticatorService loginHistoryAuthenticator, HandleToken handleToken)
        {
            _userAuthenticatorService = userAuthenticatorService;
            _loginHistoryAuthenticatorService = loginHistoryAuthenticator;
            _handleToken = handleToken;

        }

        [HttpGet("getUser")]
        public ActionResult<UserAuthenticator> GetUser(string email, string password)
        {
            string requestIP = HttpContext.Connection.RemoteIpAddress?.ToString();
            var res = _userAuthenticatorService.getUser(email, password);
            if (res == null)
            {
                return Unauthorized();
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
            var token = _handleToken.GenerateJwtToken(email,res.userId);
            return Ok(new { res, token });
        }

        [HttpPost("postUser")]
        public ActionResult PostUser([FromBody] UserAuthenticator userAuthenticator)
        {
            _userAuthenticatorService.postUser(userAuthenticator);
            return Ok("User Added Successfully");
        }

        
        [HttpGet("getHistory")]
        public ActionResult<List<LoginHistoryAuthenticator>> GetHistory()
        {
            // Get the token from the Authorization header
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Validate the token and extract the userId
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            // Extract userId claim
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim == null)
            {
                return BadRequest("User ID not found in token.");
            }

            int userId;
            if (!int.TryParse(userIdClaim.Value, out userId))
            {
                return BadRequest("Invalid User ID in token.");
            }

            // Get login history using userId
            var history = _loginHistoryAuthenticatorService.getHistory(userId);

            return Ok(history);
        }

    }
}
