using System;
using System.Collections.Generic;

public class Activity
{
    protected string _date;
    protected int _length; // in minutes

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public virtual double GetDistance() => 0.0;
    public virtual double GetSpeed() => 0.0;
    public virtual double GetPace() => 0.0;

    public virtual string GetSummary()
    {
        return $"{GetType().Name} on {_date}: Duration: {_length} min";
    }
}

public class Running : Activity
{
    private double _distance; // in miles

    public Running(string date, int length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / _length) * 60; // miles per hour
    public override double GetPace() => _length / _distance; // minutes per mile

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Distance: {_distance} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min/mile";
    }
}

public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(string date, int length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * _length) / 60; // in miles
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed; // minutes per mile

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Speed: {_speed} mph, Distance: {GetDistance():F2} miles, Pace: {GetPace():F2} min/mile";
    }
}

public class Swimming : Activity
{
    private int _laps; // number of laps

    public Swimming(string date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 0.05; // assuming each lap is 50 meters or 0.05 miles
    public override double GetSpeed() => (GetDistance() / _length) * 60; // miles per hour
    public override double GetPace() => _length / GetDistance(); // minutes per mile

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Laps: {_laps}, Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min/mile";
    }
}

public class Program
{
    public static void Main()
    {
        var activities = new List<Activity>
        {
            new Running("2024-07-22", 30, 3.0),
            new Cycling("2024-07-23", 45, 16.0),
            new Swimming("2024-07-24", 60, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}