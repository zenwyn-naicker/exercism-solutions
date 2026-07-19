class RemoteControlCar
{
    private int _battery = 100;
    private int _speed;
    private int _batteryDrain;
    private int _distance;
    private bool _isBatteryDrained = false;

    public RemoteControlCar(int carSpeed, int carBatteryDrain)
    {
        _speed = carSpeed;
        _batteryDrain = carBatteryDrain;
    }

    public bool BatteryDrained() => _isBatteryDrained;

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if((_battery > 0) && (_batteryDrain <= _battery))
        {
            _distance += _speed;
            _battery -= _batteryDrain;
        }
        if (_battery == 0 || (_battery > 0) && (_batteryDrain > _battery))
        {
            _isBatteryDrained = true;
        }
        
    }

    public static RemoteControlCar Nitro()
        => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(int dist)
    {
        _distance = dist;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();

            if (car.DistanceDriven() >= _distance)
            {
                return true;
            }
        }

        return false;
    }
}