namespace ConfigReader.Entities
{
    public class AzureKeyVaultConfigModel
    {
        public string TenantID { get; set; }
        public string ClientID { get; set; }
        public string ClientSecretID { get; set; }
        public string VaultName { get; set; }
    }
}
