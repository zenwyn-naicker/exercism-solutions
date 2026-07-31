using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
        => $"{studentA,29} ♡ {studentB,-29}";

    public static string DisplayBanner(string studentA, string studentB)
        => $"""
             ******       ******
           **      **   **      **
         **         ** **         **
        **            *            **
        **                         **
        **     {studentA} +  {studentB}    **
         **                       **
           **                   **
             **               **
               **           **
                 **       **
                   **   **
                     ***
                      *
        """;

    public static string DisplayGermanExchangeStudents(string studentA,
        string studentB, DateTime start, float hours)
    {
        CultureInfo germanCulture = CultureInfo.GetCultureInfo("de-DE");

        string message = "{0} and {1} have been dating since {2:dd.MM.yyyy} - that's {3:N2} hours";

        return string.Format(
            germanCulture,
            message,
            studentA,
            studentB,
            start,
            hours);
    }
}