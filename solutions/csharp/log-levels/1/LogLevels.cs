static class LogLine
{
    public static string Message(string logLine)
    {      
        return logLine.Split(':')[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        var trimmedLogLine = logLine.Trim();

        int start = trimmedLogLine.IndexOf('[') + 1;
        int end = trimmedLogLine.IndexOf(']');

        string level = trimmedLogLine.Substring(start, end - start);

        return level.ToLower();      
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
