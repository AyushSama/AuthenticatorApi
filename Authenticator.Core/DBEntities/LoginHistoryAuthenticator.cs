using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authenticator.Core.DBEntities
{
    public class LoginHistoryAuthenticator
    {
        [Key]
        public int historyId { get; set; }

        [ForeignKey("UserAuthenticator")]
        public int userId {  get; set; }
        public string requestIP { get; set; }
        public DateTime timestamp { get; set; }
    }
}
