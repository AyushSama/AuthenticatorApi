using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ConfigReader.Entities;
using LoggerServiceInvoker.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Diagnostics;



namespace ConfigReader
{
    public class AppConfiguration
    {
        public static AppConfigurationModel ApplyConfiguration(IConfigurationBuilder configuration)
        {
            var _appconfig = new AppConfigurationModel();
            Message message = new Message();
            try
            {

                message.Messages.AddLog("Entered in AppConfig");
                message.ApiAddress = message.ApiAddress = "ApplyConfiguration";
                message.ScreenId = (int)ScreenMasterEnum.ConfigReader;
                var configVal = configuration.Build();
                var azureConfig = configVal.GetSection("KeyVaultConfig").Get<AzureKeyVaultConfigModel>() ?? throw new Exception("KeyVaultConfig section is missing in the configuration.");
                bool blnKeyVaultConfig = Convert.ToBoolean(configVal["IsKeyVaultConfig"]);
                string strKVUrl = $"https://{azureConfig.VaultName}.vault.azure.net/";

                if (blnKeyVaultConfig)
                {
                    // Details from Key Vault
                    var credential = new ClientSecretCredential(azureConfig.TenantID, azureConfig.ClientID, azureConfig.ClientSecretID);
                    var client = new SecretClient(new Uri(strKVUrl), credential);
                    configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

                    var connectionStringJson = configVal.GetValue<string>("ConnectionStrings");
                    dynamic Connections = JObject.Parse(connectionStringJson ?? "{}");
                    _appconfig.DBConnectionString = Connections?.SqlServer ?? string.Empty;
                    _appconfig.DBLoggerConnectionString = Connections?.LoggerSqlServer ?? string.Empty;
                    _appconfig.DBStagingConnectionString = Connections?.StagingSqlServer ?? string.Empty;

                    _appconfig.CorsURL = configVal.GetValue<string>("CorsURL") ?? string.Empty;
                    _appconfig.EmailSettings = DeserializeConfig<EmailSettings>(configVal.GetValue<string>("EmailSettings"), message);
                    _appconfig.JwtSettings = DeserializeConfig<JwtSettings>(configVal.GetValue<string>("JwtSettings"), message);
                    _appconfig.BingSettings = DeserializeConfig<BingSettings>(configVal.GetValue<string>("BingSettings"), message);
                    _appconfig.CacheSettings = DeserializeConfig<CacheSettings>(configVal.GetValue<string>("CacheSettings"), message);
                    _appconfig.SwaggerSettings = DeserializeConfig<SwaggerSettings>(configVal.GetValue<string>("SwaggerSettings"), message);
                    _appconfig.LicenseSettings = DeserializeConfig<LicenseSettings>(configVal.GetValue<string>("license"), message);
                    _appconfig.SchoolDeptSettings = DeserializeConfig<SchoolDeptSettings>(configVal.GetValue<string>("SchoolDeptSettings"), message);
                    _appconfig.ClaimAntivirusSettings = DeserializeConfig<ClaimAntivirusSettings>(configVal.GetValue<string>("ClamAntivirus"), message);
                    _appconfig.LoggerSetting = DeserializeConfig<LoggerSetting>(configVal.GetValue<string>("LoggerSetting"), message);
                    _appconfig.LTMCSettings = DeserializeConfig<LTMCSettings>(configVal.GetValue<string>("LTMCSettings"), message);
                    _appconfig.Impersonate = DeserializeConfig<Impersonate>(configVal.GetValue<string>("Impersonate"), message);
                    _appconfig.UserLogSettings = DeserializeConfig<UserLogSettings>(configVal.GetValue<string>("UserLogSettings"), message);
                    _appconfig.CaptchaConfig = DeserializeConfig<CaptchaConfig>(configVal.GetValue<string>("CaptchaConfig"), message);
                    _appconfig.GenerativeAIConfig = DeserializeConfig<GenerativeAIConfig>(configVal.GetValue<string>("GenerativeAIConfig"), message);
                    _appconfig.SISSettings = DeserializeConfig<SISSettings>(configVal.GetValue<string>("SISSettings"), message);
                    _appconfig.Settings = DeserializeConfig<Settings>(configVal.GetValue<string>("Settings"), message);
                    _appconfig.Serilog = DeserializeConfig<Serilog>(configVal.GetValue<string>("Serilog"), message);
                    _appconfig.AsposeLicense = configVal.GetValue<string>("AsposeLicense") ?? string.Empty;
                    _appconfig.SecretKey = configVal.GetValue<string>("SecretKey") ?? string.Empty;
                    _appconfig.ExportDataMicroServiceEndPoint = configVal.GetValue<string>("ExportDataMicroServiceEndPoint") ?? string.Empty;
                    _appconfig.LoggerMicroServiceEndPoint = configVal.GetValue<string>("LoggerMicroServiceEndPoint") ?? string.Empty;
                    _appconfig.ProductName = configVal.GetValue<string>("ProductName") ?? string.Empty;
                }
                else
                {
                    _appconfig.DBConnectionString = configVal.GetConnectionString("SqlServer") ?? string.Empty;
                    _appconfig.DBLoggerConnectionString = configVal.GetConnectionString("LoggerSqlServer") ?? string.Empty;
                    _appconfig.DBStagingConnectionString = configVal.GetConnectionString("StagingSqlServer") ?? string.Empty;

                    _appconfig.EmailSettings = BindConfig<EmailSettings>(configVal, "EMailSettings", message);
                    _appconfig.JwtSettings = BindConfig<JwtSettings>(configVal, "JwtSettings", message);
                    _appconfig.BingSettings = BindConfig<BingSettings>(configVal, "BingSettings", message);
                    _appconfig.CacheSettings = BindConfig<CacheSettings>(configVal, "CacheSettings", message);
                    _appconfig.SwaggerSettings = BindConfig<SwaggerSettings>(configVal, "SwaggerSettings", message);
                    _appconfig.LicenseSettings = BindConfig<LicenseSettings>(configVal, "License", message);
                    _appconfig.SchoolDeptSettings = BindConfig<SchoolDeptSettings>(configVal, "SchoolDeptSettings", message);
                    _appconfig.ClaimAntivirusSettings = BindConfig<ClaimAntivirusSettings>(configVal, "ClamAntivirus", message);
                    _appconfig.LoggerSetting = BindConfig<LoggerSetting>(configVal, "LoggerSetting", message);
                    _appconfig.LTMCSettings = BindConfig<LTMCSettings>(configVal, "LTMCSettings", message);
                    _appconfig.Impersonate = BindConfig<Impersonate>(configVal, "Impersonate", message);
                    _appconfig.UserLogSettings = BindConfig<UserLogSettings>(configVal, "UserLogSettings", message);
                    _appconfig.CaptchaConfig = BindConfig<CaptchaConfig>(configVal, "CaptchaConfig", message);
                    _appconfig.GenerativeAIConfig = BindConfig<GenerativeAIConfig>(configVal, "GenerativeAIConfig", message);
                    _appconfig.SISSettings = BindConfig<SISSettings>(configVal, "SISSettings", message);
                    _appconfig.Settings = BindConfig<Settings>(configVal, "Settings", message);
                    _appconfig.Serilog = BindConfig<Serilog>(configVal, "Serilog", message);
                    _appconfig.AsposeLicense = configVal.GetValue<string>("AsposeLicense") ?? string.Empty;
                    _appconfig.SecretKey = configVal.GetValue<string>("SecretKey") ?? string.Empty;
                    _appconfig.ExportDataMicroServiceEndPoint = configVal.GetValue<string>("ExportDataMicroServiceEndPoint") ?? string.Empty;
                    _appconfig.LoggerMicroServiceEndPoint = configVal.GetValue<string>("LoggerMicroServiceEndPoint") ?? string.Empty;
                    _appconfig.ProductName = configVal.GetValue<string>("ProductName") ?? string.Empty;
                }
                LogInfo(_appconfig, message);
            }
            catch (Exception ex)
            {
                LogException(ex, _appconfig, message);

            }

            return _appconfig;
        }

        private static T DeserializeConfig<T>(string json, Message message) where T : new()
        {
            message.Messages.AddLog("Entered in AppConfig DeserializeConfig,", json);
            return string.IsNullOrEmpty(json) ? new T() : JsonConvert.DeserializeObject<T>(json);
        }

        private static T BindConfig<T>(IConfiguration config, string sectionName, Message message) where T : new()
        {

            var settings = new T();
            config.GetSection(sectionName).Bind(settings);
            message.Messages.AddLog("Entered in AppConfig DeserializeConfig,", settings.ToString());
            return settings;
        }
        public static void LogException(Exception ex, AppConfigurationModel appconfig, Message message)
        {
            StackTrace st = new StackTrace(ex, true);
            if (appconfig.LoggerSetting.ILoggerEnabled)
            {
                message.Fail();
                message.ExceptionMessage = "Login Failed " + ex.Message;
                LoggerEntity newEntity = new LoggerEntity()
                {
                    LoginCorpNo = -1,
                    MainCorpNo = -1,
                    CorpName = "App Config Nuget",
                    LogTypeEnumId = (int)LogType.Exception,
                    ExceptionsLevelEnumId = (int)ExceptionLevel.Low,
                    LoggerSetting = appconfig.LoggerSetting,
                    Message = message
                };
                var nameValueCollection = new NameValueCollection();
                LoggerServiceBase _loggerService = new LoggerServiceBase(nameValueCollection);
                _loggerService.LogException(ex, appconfig.LoggerMicroServiceEndPoint, newEntity, "73cc7881-297d-4670-8d95-54a00692f1ab");
            }
        }

        public static void LogInfo(AppConfigurationModel appconfig, Message message)
        {
            if (appconfig.LoggerSetting.ILoggerEnabled)
            {
                LoggerEntity newEntity = new LoggerEntity()
                {
                    Message = message,
                    LogTypeEnumId = (int)LogType.Information,
                    LoggerSetting = appconfig.LoggerSetting,
                    MainCorpNo = -1,
                    LoginCorpNo = -1,
                    CorpName = "App Config Nuget",
                    ExceptionsLevelEnumId = null
                };
                var nameValueCollection = new NameValueCollection();
                LoggerServiceBase _loggerService = new LoggerServiceBase(nameValueCollection);
                _loggerService.LogInfo(appconfig.LoggerMicroServiceEndPoint, newEntity, "73cc7881-297d-4670-8d95-54a00692f1ab");
            }
        }

    }
}