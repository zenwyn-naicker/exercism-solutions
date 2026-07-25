enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{

    public static LogLevel ParseLogLevel(string logLine)
    {
        int startIndex = logLine.IndexOf("[") + 1;
        int endIndex = logLine.IndexOf("]");
        
        string logLevel = logLine.Substring(startIndex, endIndex - startIndex);
        
        return logLevel switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return logLevel switch
        {
            LogLevel.Unknown => $"{(int)LogLevel.Unknown}:{message}",
            LogLevel.Trace => $"{(int)LogLevel.Trace}:{message}",
            LogLevel.Debug => $"{(int)LogLevel.Debug}:{message}",
            LogLevel.Info => $"{(int)LogLevel.Info}:{message}",
            LogLevel.Warning => $"{(int)LogLevel.Warning}:{message}",
            LogLevel.Error => $"{(int)LogLevel.Error}:{message}",
            LogLevel.Fatal => $"{(int)LogLevel.Fatal}:{message}"
        };
    }
}