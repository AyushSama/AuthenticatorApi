using ConfigReader;
using ConfigReader.Entities;
using Letstalk.Areas.LoggerMicroServices.Constants;
using LoggerServiceInvoker.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace LoggerServiceInvoker.Common
{
    public class LoggerServiceBase : ILoggerServiceBase
    {
        private readonly NameValueCollection _appSettings;

        public LoggerServiceBase(NameValueCollection appSettings)
        {
            _appSettings = appSettings;
        }
        public void LogInfo(Message message, int loginCorpNo, int mainCorpNo, string corpName, string SecretKey)
        {
            bool isILoggerEnabled;
            if (!string.IsNullOrEmpty(_appSettings["ILoggerEnabled"]) && bool.TryParse(_appSettings["ILoggerEnabled"], out isILoggerEnabled) && isILoggerEnabled)
            {
                int environmentValue = 0;
                string environmentName = _appSettings["environment"];

                ConfigReader.Entities.Environment environment;
                if (Enum.TryParse<ConfigReader.Entities.Environment>(environmentName, out environment))
                {
                    environmentValue = (int)environment;
                }
                message.UserMessage = MessageConstants.Somethingwrong;

                LoggerEntity newEntity = new LoggerEntity
                {
                    Message = message,
                    LogTypeEnumId = (int)LogType.Information,
                    LoggerSetting = new LoggerSetting
                    {
                        Environment = environmentValue,
                        StorageMediaType = _appSettings["StorageMediaType"],
                    },
                    LoginCorpNo = loginCorpNo,
                    MainCorpNo = mainCorpNo,
                    ExceptionsLevelEnumId = (int)ExceptionLevel.Low,
                    CorpName = corpName
                };
                SaveLog(_appSettings["LoggerMicroServiceEndPoint"], newEntity, SecretKey);
            }


        }
        public void LogInfo(NameValueCollection appSettings, LoggerEntity newEntity, string SecretKey)
        {
            SaveLog(_appSettings["LoggerMicroServiceEndPoint"], newEntity, SecretKey);
        }
        public void LogInfo(string loggerUrl, LoggerEntity newEntity, string SecretKey)
        {
            SaveLog(loggerUrl, newEntity, SecretKey);
        }
        public void LogException(Exception ex, Message message, int loginCorpNo, int mainCorpNo, string corpName, string secretKey)
        {
            StackTrace st = new StackTrace(ex, true);
            StackFrame[] frames = st.GetFrames();
            StackFrame lastFrame = frames?.FirstOrDefault(s => s.GetFileName() != null);
            message.Messages.AddLog(ex, lastFrame);
            if (bool.TryParse(_appSettings["ILoggerEnabled"], out bool isILoggerEnabled) && isILoggerEnabled)
            {
                string environmentName = _appSettings["environment"];
                int environmentValue = Enum.TryParse(environmentName, out ConfigReader.Entities.Environment environment) ? (int)environment : 0;
                var newEntity = new LoggerEntity
                {
                    Message = message,
                    LogTypeEnumId = (int)LogType.Information,
                    LoggerSetting = new LoggerSetting
                    {
                        Environment = environmentValue,
                        StorageMediaType = _appSettings["StorageMediaType"],
                    },
                    LoginCorpNo = loginCorpNo,
                    MainCorpNo = mainCorpNo,
                    ExceptionsLevelEnumId = (int)ExceptionLevel.Low,
                    CorpName = corpName
                };
                SaveLog(_appSettings["LoggerMicroServiceEndPoint"], newEntity, secretKey);
            }
        }
        public void LogException(Exception ex, NameValueCollection appSettings, LoggerEntity newEntity, string SecretKey)
        {
            StackTrace st = new StackTrace(ex, true);
            StackFrame[] frames = st.GetFrames();
            StackFrame lastFrame = frames?.FirstOrDefault(s => s.GetFileName() != null);
            newEntity.Message.Messages.AddLog(ex, lastFrame);
            SaveLog(_appSettings["LoggerMicroServiceEndPoint"], newEntity, SecretKey);
        }
        public void LogException(Exception ex, string loggerUrl, LoggerEntity newEntity, string SecretKey)
        {
            StackTrace st = new StackTrace(ex, true);
            StackFrame[] frames = st.GetFrames();
            StackFrame lastFrame = frames?.FirstOrDefault(s => s.GetFileName() != null);
            newEntity.Message.Messages.AddLog(ex, lastFrame);
            SaveLog(loggerUrl, newEntity, SecretKey);
        }
        protected void SaveLog(string apiurl, LoggerEntity newEntity, string SecretKey)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient(handler);
            try
            {
                string json = JsonConvert.SerializeObject(newEntity);
                string apiUrl = apiurl;
                client.DefaultRequestHeaders.Add("SecretKey", SecretKey);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                client.PostAsync(apiUrl, content);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: " + exc.Message);
            }
        }
    }
}
