using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Controllers
{
    [ApiController]
    public class ManageDetailsController : ControllerBase
    {
        [HttpGet("getSurveyDetails")]
        public ActionResult getGetSurveyDetails()
        {
            return Ok(new { message = "GetSurveyDetails is Working" });
        }
        [HttpGet("editSplashScreen")]
        public ActionResult getEditSplashScreen()
        {
            return Ok(new { message = "EditSplashScreen is Working" });
        }
        [HttpGet("editReleaseBannerText")]
        public ActionResult getEditReleaseBannerText()
        {
            return Ok(new { message = "EditReleaseBannerText is Working" });
        }
        [HttpGet("unlockAccount")]
        public ActionResult getUnlockAccount()
        {
            return Ok(new { message = "UnlockAccount is Working" });
        }
        [HttpGet("emptyRecycleBin")]
        public ActionResult getEmptyRecycleBin()
        {
            return Ok(new { message = "EmptyRecycleBin is Working" });
        }
        [HttpGet("publishCustomReport")]
        public ActionResult getPublishCustomReport()
        {
            return Ok(new { message = "PublishCustomReport is Working" });
        }
        [HttpGet("domainLevelOptOut")]
        public ActionResult getDomainLevelOptOut()
        {
            return Ok(new { message = "DomainLevelOptOut is Working" });
        }
        [HttpGet("lDAPAccounts")]
        public ActionResult getLDAPAccounts()
        {
            return Ok(new { message = "LDAPAccounts is Working" });
        }
        [HttpGet("phishingControl")]
        public ActionResult getPhishingControl()
        {
            return Ok(new { message = "PhishingControl is Working" });
        }
        [HttpGet("lTDepartmentUserManagement")]
        public ActionResult getLTDepartmentUserManagement()
        {
            return Ok(new { message = "LTDepartmentUserManagement is Working" });
        }
        [HttpGet("lTInitialSetup")]
        public ActionResult getLTInitialSetup()
        {
            return Ok(new { message = "LTInitialSetup is Working" });
        }
        [HttpGet("activityDirectorySetup")]
        public ActionResult getActivityDirectorySetup()
        {
            return Ok(new { message = "ActivityDirectorySetup is Working" });
        }
    }
}
