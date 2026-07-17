public static class LogAnalysis 
{
    public static string SubstringAfter(this string message, string delimiter)
    {
        int startIndex = message.IndexOf(delimiter) + delimiter.Length;
        return message.Substring(startIndex);
    }
    
    public static string SubstringBetween(this string message,
        string delimiterOne,
        string delimiterTwo)
    {
        int startIndex = message.IndexOf(delimiterOne) + delimiterOne.Length;
        int endIndex = message.IndexOf(delimiterTwo, startIndex);
    
        return message.Substring(startIndex, endIndex - startIndex);
    }
    
    public static string Message(this string message)
    {
        return message.SubstringAfter(": ");
    }
    
    public static string LogLevel(this string message)
    {
        return message.SubstringBetween("[", "]");
    }
}