using System.Dynamic;
using System.Numerics;

namespace Classes; // define the directory

public class Trip // the name of the class
{
    public Trip(float miles, float speed, float stops, float stopTime) // the values of the object stored
    {
        Miles = miles;
        Speed = speed;
        Stops = stops;
        StopTime = stopTime;
    }
    public double CalculateTime() // calculate the time, it will be a double (long float)
    {
        float timeDriving = Miles / Speed; // time driven
        double timeStopped = Stops * StopTime / 60; // time stopped
        return timeDriving + timeStopped; // return the sum of the two
    }

    public float Miles { get; } // initializer variables
    public float Speed { get; }
    public float Stops { get; }
    public float StopTime { get; }
    
}