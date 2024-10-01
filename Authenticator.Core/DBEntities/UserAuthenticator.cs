using System.ComponentModel.DataAnnotations;

namespace Authenticator.Core.DBEntities
{
    public class UserAuthenticator
    {
        [Key]
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime createdDate { get; set; }
    }
}
