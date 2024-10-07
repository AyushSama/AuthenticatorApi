using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.LoginAttemptService;
using Authenticator.TokenHandler;
using ConfigReader.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authenticator.CustomActionFilters
{
    public class Authenticate : Attribute, IActionFilter
    {

        private readonly FailedLoginAttemptsService _failedAttemptsService;
        private readonly IAdminMasterUserService _adminMasterUserService;
        private readonly HandleToken _handleToken;

        public Authenticate(FailedLoginAttemptsService failedAttemptsService,
                            IAdminMasterUserService adminMasterUserService,
                            HandleToken handleToken)
        {
            _failedAttemptsService = failedAttemptsService;
            _adminMasterUserService = adminMasterUserService;
            _handleToken = handleToken;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {   
            var username = context.ActionArguments["username"]?.ToString();
            var password = context.ActionArguments["password"]?.ToString();

            if (_failedAttemptsService.IsBlocked(username))
            {
                context.Result = new StatusCodeResult(429); // Too many attempts
                return;
            }

            var message = new Message();
            var user = _adminMasterUserService.authenticateUser(username, password, message);

            if (user == null)
            {
                // Record failed attempt
                _failedAttemptsService.RecordFailedAttempt(username);
                context.Result = new UnauthorizedResult();
                return;
            }

            // Reset attempts on successful login
            _failedAttemptsService.ResetAttempts(username);

            var token = _handleToken.GenerateJwtToken(username, (int)(user.ID)); // Assuming UserId is a property of AdminMasterUser

            // Set cookie
            string cookieName = "token";
            string cookieValue = token;
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                Path = "/",
                Secure = false,
                HttpOnly = true
            };

            context.HttpContext.Response.Cookies.Append(cookieName, cookieValue, cookieOptions);

            // Store the authenticated user in HttpContext
            context.HttpContext.Items["AuthenticatedUser"] = user;
            context.HttpContext.Items["token"] = token;
        }
    }
}
