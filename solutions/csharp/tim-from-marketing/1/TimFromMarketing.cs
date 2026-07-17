static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        if (!id.HasValue)
        {
            return $"{name} - {(department ?? "OWNER").ToUpper()}";
        }
        
        return $"[{id}] - {name} - {(department ?? "OWNER").ToUpper()}";
    }
}