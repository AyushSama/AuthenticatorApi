using System.ComponentModel.DataAnnotations.Schema;

namespace Authenticator.Core.DBEntities
{
    public class LoginHistoryAuthenticator
    {
        [ForeignKey("UserAuthenticator")]
        public int userId {  get; set; }
        public string requestIP { get; set; }
        public DateTime timestamp { get; set; }
    }
}
