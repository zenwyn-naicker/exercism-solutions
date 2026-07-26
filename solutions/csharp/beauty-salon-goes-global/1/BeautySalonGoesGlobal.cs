using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
        => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime dateTime = DateTime.Parse(appointmentDateDescription);

        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        string timeZoneId;

        if (isWindows)
        {
            timeZoneId = location switch
            {
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "W. Europe Standard Time",
            };
        }
        else
        {
            timeZoneId = location switch
            {
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
            };
        }

        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
        => alertLevel switch
        {
            AlertLevel.Early =>
                appointment.AddDays(-1),

            AlertLevel.Standard =>
                appointment
                    .AddHours(-1)
                    .AddMinutes(-45),

            AlertLevel.Late =>
                appointment.AddMinutes(-30),
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        string timeZoneId;

        if (isWindows)
        {
            timeZoneId = location switch
            {
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "W. Europe Standard Time",
            };
        }
        else
        {
            timeZoneId = location switch
            {
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
            };
        }

        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        DateTime previousDate = dt.AddDays(-7);

        return timeZone.IsDaylightSavingTime(dt)
            != timeZone.IsDaylightSavingTime(previousDate);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo culture = location switch
        {
            Location.NewYork => new CultureInfo("en-US"),

            Location.London => new CultureInfo("en-GB"),

            Location.Paris => new CultureInfo("fr-FR"),
        };

        bool success = DateTime.TryParse(
            dtStr,
            culture,
            out DateTime result);

        if (success)
        {
            return result;
        }

        return DateTime.MinValue;
    }
}