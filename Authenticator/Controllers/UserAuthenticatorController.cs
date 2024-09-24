using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.LoginAttemptService;
using Authenticator.Core.DBEntities;
using Authenticator.TokenHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

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
        public async Task<IActionResult> GetUser(string email, string password,string? captcha)
        {
            string requestIP = HttpContext.Connection.RemoteIpAddress?.ToString();
             var failedAttemptsService = HttpContext.RequestServices.GetService<FailedLoginAttemptsService>();

            if (!string.IsNullOrEmpty(captcha))

            {
                var isCaptchaValid = await VerifyCaptcha(captcha);  // You'll need to implement this
                if (!isCaptchaValid)
                {
                    failedAttemptsService.ResetAttempts(email);
                    return BadRequest(new { message = "Invalid CAPTCHA", showCaptcha = true });
                }
            }

            // Check if the user is blocked
            if (failedAttemptsService.IsBlocked(email))
            {
                return StatusCode(429, "Too many failed attempts. Please try again later.");
            }

            var res = _userAuthenticatorService.getUser(email, password);

            if (res == null)
            {
                // Record failed attempt
                failedAttemptsService.RecordFailedAttempt(email);
                return Unauthorized();
            }
            else
            {
                // Reset attempts on successful login
                failedAttemptsService.ResetAttempts(email);

                LoginHistoryAuthenticator loginHistoryAuthenticator = new LoginHistoryAuthenticator()
                {
                    userId = res.userId,
                    requestIP = requestIP,
                    status = true,
                    timestamp = DateTime.UtcNow,
                };
                _loginHistoryAuthenticatorService.Log(loginHistoryAuthenticator);
            }

            var token = _handleToken.GenerateJwtToken(email, res.userId);
            return Ok(new { res, token });
        }


        [HttpPost("postUser")]
        public ActionResult PostUser([FromBody] UserAuthenticator userAuthenticator)
        {   
            userAuthenticator.createdDate = DateTime.UtcNow;
            _userAuthenticatorService.postUser(userAuthenticator);
            return Ok(new { message = "User Added Successfully" });
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

        [NonAction]
        private async Task<bool> VerifyCaptcha(string captchaResponse)
        {
            var secretKey = "6Le2V00qAAAAANDaOsvgbQYhTnn4uGQfZlHtbvVv"; // Replace with your actual secret key
            var client = new HttpClient();

            var response = await client.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={captchaResponse}", null);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);
                return result.success == true; // Check if the CAPTCHA verification was successful
            }

            return false; // If the request to Google fails, consider it as invalid
        }

    }
}
