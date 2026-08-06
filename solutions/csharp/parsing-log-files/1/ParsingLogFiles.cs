using System.Text.RegularExpressions;
public class LogParser
{
    public bool IsValidLine(string text)
        => Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    public string[] SplitLogLine(string text)
        => Regex.Split(text, @"<[-^*=]+>");

    public int CountQuotedPasswords(string lines)
    {
        int count = 0;
        foreach (string line in Regex.Split(lines, @"\r\n|\r|\n"))
        {
            if (Regex.IsMatch(line, @"""[^""]*password[^""]*""", RegexOptions.IgnoreCase))
            {
                count++;
            }
        }
        return count;
    }

    public string RemoveEndOfLineText(string line)
        => Regex.Replace(line, @"end-of-line\d+", "");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] results = new string[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            Match match = Regex.Match(
                lines[i],
                @"\bpassword\S+",
                RegexOptions.IgnoreCase
            );
            results[i] = match.Success ? $"{match.Value}: {lines[i]}" : $"--------: {lines[i]}"; 
        }
        return results;
    }
}
