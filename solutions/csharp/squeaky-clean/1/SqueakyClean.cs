using System.Text;
public static class Identifier
{
    public static string Clean(string identifier)
{
    StringBuilder result = new StringBuilder();
    bool capitaliseNext = false;

    foreach (char c in identifier)
    {
        bool isGreekLowercase = c >= 'α' && c <= 'ω';

        if (char.IsControl(c))
        {
            result.Append("CTRL");
        }
        else if (c == ' ')
        {
            result.Append('_');
        }
        else if (c == '-')
        {
            capitaliseNext = true;
        }
        else if (char.IsLetter(c) && !isGreekLowercase)
        {
            if (capitaliseNext)
            {
                result.Append(char.ToUpperInvariant(c));
                capitaliseNext = false;
            }
            else
            {
                result.Append(c);
            }   
        }
    }

    return result.ToString();
}
}
