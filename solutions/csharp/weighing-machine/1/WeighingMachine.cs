class WeighingMachine
{
    private double _weight;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }

    public double Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight
    {
        get
        {
            double result = Weight - TareAdjustment;

            return result.ToString($"F{Precision}") + " kg";
        }
    }
}