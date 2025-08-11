using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50.0 / 1000.0) * 0.62;

    public override double GetSpeed() => (GetDistance() / LengthMinutes) * 60;

    public override double GetPace() => LengthMinutes / GetDistance();
}
