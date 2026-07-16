public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber)
        Analyze(string phoneNumber)
    {
        int delimiter1 = phoneNumber.IndexOf("-");

        string firstThree = phoneNumber.Substring(0, 3);

        bool IsNewYork = firstThree == "212";

        int delimiter2 = phoneNumber.IndexOf("-", delimiter1 + 1);

        string middleThree = phoneNumber.Substring(delimiter1 + 1, 3);

        bool IsFake = middleThree == "555";

        string LocalNumber = phoneNumber.Substring(delimiter2 + 1);

        return (IsNewYork, IsFake, LocalNumber);
    }

    public static bool IsFake(
        (bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}