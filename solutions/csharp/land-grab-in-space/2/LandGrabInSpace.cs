public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        C1 = c1;
        C2 = c2;
        C3 = c3;
        C4 = c4;
    }

    public Coord C1 { get; }
    public Coord C2 { get; }
    public Coord C3 { get; }
    public Coord C4 { get; }
}


public class ClaimsHandler
{
    private List<Plot> _registeredList = new List<Plot>();
    
    public void StakeClaim(Plot plot)
    {
        _registeredList.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
        => _registeredList.Contains(plot);

    public bool IsLastClaim(Plot plot)
    {
        if (_registeredList.Count > 0)
        {
            return plot.Equals(_registeredList[_registeredList.Count - 1]);
        }
        return false;
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot longestPlot = default;
        int longestSide = 0;
        foreach (Plot p in _registeredList)
        {    
            int pLongestSide = GetLongestSide(p);
            if (pLongestSide > longestSide)
            {
                longestPlot = p;
                longestSide = pLongestSide;
            }     
        } 
        return longestPlot;
    }

    private int GetLongestSide(Plot p)
    {
            ushort maxX = 
                Math.Max(Math.Max(p.C1.X, p.C2.X), 
                         Math.Max(p.C3.X, p.C4.X));
            ushort maxY = 
                Math.Max(Math.Max(p.C1.Y, p.C2.Y), 
                         Math.Max(p.C3.Y, p.C4.Y));
            ushort minX = 
                Math.Min(Math.Min(p.C1.X, p.C2.X), 
                         Math.Min(p.C3.X, p.C4.X));
            ushort minY = 
                Math.Min(Math.Min(p.C1.Y, p.C2.Y), 
                         Math.Min(p.C3.Y, p.C4.Y));
            return Math.Max(maxX - minX, maxY - minY); 
    }
}
