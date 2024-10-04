namespace ConfigReader.Entities
{
    public class TokenClaimModel
    {
        public string Token { get; set; }
        public int MainCorpNo { get; set; }
        public int LoginCorpNo { get; set; }
        public bool IsSubAdmin { get; set; }
        public bool IsAdminRights { get; set; }
        public int TimeZoneId { get; set; }
        public int TimeZoneDiffinSec { get; set; }
        public string FolderName { get; set; }
        public string Creator { get; set; }
        public string CorporateName { get; set; }
        public int AccountType { get; set; }
        public int AccountDateFormat { get; set; }
        public int AccountTimeFormat { get; set; }
        public bool IsNogin { get; set; }
        public int MasterLogin { get; set; }
        public int LtmcCorpNo { get; set; }
        public string Ip { get; set; }
        public string Email { get; set; }
        public int PermissionId { get; set; }

    }
}
