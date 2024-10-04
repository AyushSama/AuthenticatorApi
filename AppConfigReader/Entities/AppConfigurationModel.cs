using System;
using System.Collections.Generic;

namespace ConfigReader.Entities
{
    public class AppConfigurationModel
    {
        public AppConfigurationModel()
        {
            JwtSettings = new JwtSettings();
            BingSettings = new BingSettings();
            CacheSettings = new CacheSettings();
            EmailSettings = new EmailSettings();
            SwaggerSettings = new SwaggerSettings();
            LicenseSettings = new LicenseSettings();
            SchoolDeptSettings = new SchoolDeptSettings();
            ClaimAntivirusSettings = new ClaimAntivirusSettings();
            LoggerSetting = new LoggerSetting();
            LTMCSettings = new LTMCSettings();
            Impersonate = new Impersonate();
            UserLogSettings = new UserLogSettings();
            CaptchaConfig = new CaptchaConfig();
            SwitchtoEngage = new SwitchEngage();
            GenerativeAIConfig = new GenerativeAIConfig();
        }

        public BingSettings BingSettings { get; set; }
        public CacheSettings CacheSettings { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public SwaggerSettings SwaggerSettings { get; set; }
        public string DBConnectionString { get; set; }
        public string DBLoggerConnectionString { get; set; }
        public string DBStagingConnectionString { get; set; }
        public LicenseSettings LicenseSettings { get; set; }
        public SchoolDeptSettings SchoolDeptSettings { get; set; }
        public ClaimAntivirusSettings ClaimAntivirusSettings { get; set; }
        public LoggerSetting LoggerSetting { get; set; }
        public LTMCSettings LTMCSettings { get; set; }
        public Impersonate Impersonate { get; set; }
        public UserLogSettings UserLogSettings { get; set; }
        public string SecretKey { get; set; }
        public CaptchaConfig CaptchaConfig { get; set; }
        public string CorsURL { get; set; }
        public decimal ServerTimeZoneId { get; set; }
        public string AsposeLicense { get; set; }
        public string ExportDataMicroServiceEndPoint { get; set; }
        public string LoggerMicroServiceEndPoint { get; set; }
        public SwitchEngage SwitchtoEngage { get; set; }
        public GenerativeAIConfig GenerativeAIConfig { get; set; }
        public SISSettings SISSettings { get; set; }
        public Settings Settings { get; set; }
        public Serilog Serilog { get; set; }
        public string ProductName { get; set; }
    }

    public class BingSettings
    {
        public BingSettings()
        {
            DisabledLang = new List<Int64>();
            TranslateToLeftLang = new List<Int64>();
        }
        public string BingAPIEndpoint { get; set; }

        public string Key { get; set; }

        public string Region { get; set; }

        public List<Int64> DisabledLang { get; set; }

        public List<Int64> TranslateToLeftLang { get; set; }

    }
    public class CacheSettings
    {
        public string LT_Cache_Node { get; set; }
        public string RedisCacheConfig { get; set; }
    }
    public class EmailSettings
    {
        public string EmailQueuePath { get; set; }
        public string AspEmail_RegKey { get; set; }
        public string EmailHost { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public string StrLtEmailServer { get; set; }
        public string StrStaticDomain { get; set; }
        public string StrAuthSelector { get; set; }
        public string StrStaticSelector { get; set; }
        public string EmailTemplatePath { get; set; }
        public string TranslationReviewMailSubject { get; set; }
        public string Image_clients { get; set; }
        public string Email_clients_ssl { get; set; }
        public string MS_host_ssl { get; set; }
        public string MS_host { get; set; }
        public int EmailPort { get; set; }
        public int EmailTimeout { get; set; }
        public string Lang { get; set; }
        public string NewNumberRequestEmail { get; set; }
        public string Image_server { get; set; }
        public string Image_host_ssl { get; set; }
        public string DoNotReplyEmail { get; set; }
        public int CoolDownPeriod { get; set; }
        public int ExpiryLockPeriod { get; set; }
        public string SupportEmailID { get; set; }
        public string LT_OpenEmailID { get; set; }
        public string LT_CloseEmailID { get; set; }
        public string MailBeeLicenseKey { get; set; }
        public string lt_DialogueEmailPassword { get; set; }
        public string LT_Download_Server { get; set; }
    }
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int MinutesToExpiration { get; set; }

        public TimeSpan Expire => TimeSpan.FromMinutes(MinutesToExpiration);
        public int RefreshTokenValidDays { get; set; }
        public int TokenAuthorize { get; set; }
    }
    public class SwaggerSettings
    {
        public string IsSwaggerOnProd { get; set; }
    }
    public class LicenseSettings
    {
        public string AsposeLicensePath { get; set; }
    }
    public class SchoolDeptSettings
    {
        public string UploadFolderPath { get; set; }
        public string TempFolderPath { get; set; }
        public string ClamAVPath { get; set; }
    }
    public class ClaimAntivirusSettings
    {
        public string ClamAntivirus { get; set; }
    }

    public class LTMCSettings
    {
        public string LTDeleteCasePwd { get; set; }
        public string UIFolderPath { get; set; }
        public string Imagehost { get; set; }
        public string IsLTLogin { get; set; }
        public string GoogleAnalyticsBlockedIP { get; set; }
        public string LTGoogleAnalytics { get; set; }
        public string LoggerPath { get; set; }
        public string Culture { get; set; }
        public string CaptchaKey { get; set; }
        public string CaptchaSecret { get; set; }
        public string WordCloudAPIURL { get; set; }
        public string WordCloudAPIsecret { get; set; }
        public string WebRoot { get; set; }
        public string LTEmailTemplatePath { get; set; }
        public string iLoggerURL { get; set; }
        public string LT_ConfigCorp { get; set; }
        public int ServerTimeZoneId { get; set; }
        public string NotificationsEmail_k12 { get; set; }
        public string AdminEmail { get; set; }
        public string title { get; set; }
        public string BounceEmail { get; set; }
        public string LT_DialogueEmailDomain { get; set; }
        public string CreateEmailTargetURL { get; set; }
        public string LTAzuretokenEndpoint { get; set; }
        public string LTAzuregrantType { get; set; }
        public string LTAzureAppClientID { get; set; }
        public string scopes { get; set; }
        public string LTAzureClientSecret { get; set; }
        public string LTAzureTenantID { get; set; }
        public string LTGoogleSignInKey { get; set; }
        public string LTGoogleSignInSecret { get; set; }
        public bool IsOAuthEnabled { get; set; }
    }
    public class Impersonate
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLogSettings
    {
        public UserLogSettings()
        {
            ms_host = "localhost";
        }
        public string ms_host { get; set; }
    }
    public class CaptchaConfig
    {
        public string CaptchaKey { get; set; }
        public string CaptchaSecret { get; set; }
        public string CaptchaUrl { get; set; }
    }
    public class SwitchEngage
    {
        public bool isClassicAvailable { get; set; }
        public string Advance_Server_URL { get; set; }
        public string Classic_Server_URL { get; set; }
        public string Engage_Server_URL { get; set; }
    }

    public class GenerativeAIConfig
    {
        public string APIEndpoint { get; set; }
        public string SecretKey { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class SISSettings
    {
        public string BulkInsert { get; set; }
        public string limitForAPI { get; set; }
    }

    public class Settings
    {
        public string URL { get; set; }
        public string WorldColudURL { get; set; }
        public string Authorization { get; set; }
        public Int64 TopRows { get; set; }
        public Int64 Delay { get; set; }
        public string Corpno { get; set; }
        public string Mode { get; set; }
        public string exeRootPath { get; set; }
        public string clientroot { get; set; }
    }

    public class Args
    {
        public string path { get; set; }
        public string rollingInterval { get; set; }
        public string outputTemplate { get; set; }
    }

    public class MinimumLevel
    {
        public string Default { get; set; }
    }

    public class Serilog
    {
        public List<string> Using { get; set; }
        public MinimumLevel MinimumLevel { get; set; }
        public List<WriteTo> WriteTo { get; set; }
    }

    public class WriteTo
    {
        public string Name { get; set; }
        public Args Args { get; set; }
    }

}