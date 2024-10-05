using ConfigReader.Entities;
using System;
using System.Collections.Specialized;

namespace LoggerServiceInvoker.Interface
{
    public interface ILoggerServiceBase
    {
        void LogInfo(Message message, int loginCorpNo, int mainCorpNo, string corpName, string SecretKey);
        void LogInfo(NameValueCollection appSettings, LoggerEntity newEntity, string SecretKey);
        void LogInfo(string loggerUrl, LoggerEntity newEntity, string SecretKey);
        void LogException(Exception ex, Message message, int loginCorpNo, int mainCorpNo, string corpName, string SecretKey);
        void LogException(Exception ex, NameValueCollection appSettings, LoggerEntity newEntity, string SecretKey);
        void LogException(Exception ex, string loggerUrl, LoggerEntity newEntity, string SecretKey);

    }
}
