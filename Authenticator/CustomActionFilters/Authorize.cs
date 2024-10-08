using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace Authenticator.CustomActionFilters
{
    public class Authorize : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Validate the token and extract the userId
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            // Extract userId claim
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim == null)
            {
                context.Result = new BadRequestObjectResult("User ID not found in token.");
                return;
            }

            int userId;
            if (!int.TryParse(userIdClaim.Value, out userId))
            {
                context.Result = new BadRequestObjectResult("Invalid User ID in token.");
                return;
            }

        }
    }
}
