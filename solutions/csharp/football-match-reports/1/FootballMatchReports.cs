public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            >= 3 and <= 4 => "center back",
            5 => "right back",
            >= 6 and <= 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => "UNKNOWN"
        };
    }

    public static string AnalyzeOffField(object report)
    {
        return report switch
        {
            int supporters => $"There are {supporters} supporters at the match.",

            string announcement => $"{announcement}",

            Foul foul => foul.GetDescription(),

            Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.", 

            Incident incident => incident.GetDescription(),

            Manager manager when manager.Club == null => $"{manager.Name}",

            Manager manager => $"{manager.Name} ({manager.Club})",

            _ => ""
        };
    }
}