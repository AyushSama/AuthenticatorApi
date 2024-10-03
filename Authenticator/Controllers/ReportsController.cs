using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers
{
    [ApiController]
    public class ReportsController : Controller
    {
        [HttpGet("accountSummary")]
        public ActionResult getAccountSummary()
        {
            return Ok(new {message = "AccountSummary is Working!!"});
        }

        [HttpGet("loginDetails")]
        public ActionResult getLoginDetails()
        {
            return Ok(new { message = "LoginDetails is Working!!" });
        }

        [HttpGet("specialCaseParticipantsList")]
        public ActionResult getSpecialCaseParticipantsList()
        {
            return Ok(new { message = "SpecialCaseParticipantsList is Working!!" });
        }

        [HttpGet("distributionDetails")]
        public ActionResult getDistributionDetails()
        {
            return Ok(new { message = "DistributionDetails is Working!!" });
        }

        [HttpGet("clientList")]
        public ActionResult getClientList()
        {
            return Ok(new { message = "ClientList is Working!!" });
        }

        [HttpGet("timeZoneDetails")]
        public ActionResult getTimeZoneDetails()
        {
            return Ok(new { message = "TimeZoneDetails is Working!!" });
        }

    }
}
