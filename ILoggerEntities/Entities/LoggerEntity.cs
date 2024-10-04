using System;

namespace ConfigReader.Entities
{
    public class LoggerEntity
    {
        public Message Message { get; set; }
        public LoggerSetting LoggerSetting { get; set; }
        public int MainCorpNo { get; set; }
        public int LoginCorpNo { get; set; }
        public int LogTypeEnumId { get; set; }
        public int? ExceptionsLevelEnumId { get;set; }
        public string CorpName { get; set; }
    }

    public class LoggerSetting
    {
        public string StorageMediaType { get; set; }
        public int Environment { get; set; }
        public string FilePath { get; set; }
        public string RollingInterVal { get; set; }
        public string LogTrailTemplate { get; set; }
        public string FileNameFormat { get; set; }
        public Boolean ILoggerEnabled { get; set; }
        public string Loglevel { get; set; }
    }

}
