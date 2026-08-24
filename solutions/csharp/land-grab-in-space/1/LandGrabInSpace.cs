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
            return plot.Equals(_registeredList[_registeredList.Count - 1]) ;
        }
        return false;
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot longestPlot = 
            new Plot(new Coord(0,0), new Coord(0,0), new Coord(0,0), new Coord(0,0));
        foreach (Plot p in _registeredList)
        {
            ushort longestPlotMaxX = 
                Math.Max(Math.Max(longestPlot.C1.X, longestPlot.C2.X), 
                         Math.Max(longestPlot.C3.X, longestPlot.C4.X));
            ushort longestPlotMaxY = 
                Math.Max(Math.Max(longestPlot.C1.Y, longestPlot.C2.Y), 
                         Math.Max(longestPlot.C3.Y, longestPlot.C4.Y));

            ushort pMaxX = 
                Math.Max(Math.Max(p.C1.X, p.C2.X), 
                         Math.Max(p.C3.X, p.C4.X));
            ushort pMaxY = 
                Math.Max(Math.Max(p.C1.Y, p.C2.Y), 
                         Math.Max(p.C3.Y, p.C4.Y));

            ushort longestPlotMinX = 
                Math.Min(Math.Min(longestPlot.C1.X, longestPlot.C2.X), 
                         Math.Min(longestPlot.C3.X, longestPlot.C4.X));
            ushort longestPlotMinY = 
                Math.Min(Math.Min(longestPlot.C1.Y, longestPlot.C2.Y), 
                         Math.Min(longestPlot.C3.Y, longestPlot.C4.Y));

            ushort pMinX = 
                Math.Min(Math.Min(p.C1.X, p.C2.X), 
                         Math.Min(p.C3.X, p.C4.X));
            ushort pMinY = 
                Math.Min(Math.Min(p.C1.Y, p.C2.Y), 
                         Math.Min(p.C3.Y, p.C4.Y));
            
            int longestPlotLongestSide = 
                Math.Max(longestPlotMaxX - longestPlotMinX, longestPlotMaxY - longestPlotMinY);
            int pLongestSide = 
                Math.Max(pMaxX - pMinX, pMaxY - pMinY);

            if (pLongestSide > longestPlotLongestSide)
            {
                longestPlot = p;
            }     
        } 
        return longestPlot;
    }
}
