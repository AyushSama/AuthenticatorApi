using System.ComponentModel.DataAnnotations;

namespace Authenticator.Core.DBEntities
{
    public class AdminMasterUser
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string Country {  get; set; }
        public DateTime zDate {  get; set; }
        [Key]
        public decimal ID { get; set; }
        public bool IsDeleted {  get; set; }
        public bool isHipaaEnabled {  get; set; }
        public string? Email_address {  get; set; }
        public bool IsActivator {  get; set; }
        public bool IsDeletecase {  get; set; }
        public bool IsNogin {  get; set; }
        public byte AdminRole {  get; set; }
    }
}
