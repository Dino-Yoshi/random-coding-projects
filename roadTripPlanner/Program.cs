// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using Classes;

Console.WriteLine("How many miles are driven?"); 
float miles = Convert.ToInt32(Console.ReadLine()); // prompt user for miles driven
Console.WriteLine("How fast will you drive?");
float speed = Convert.ToInt32(Console.ReadLine()); // prompt user for speed in mph
Console.WriteLine("How many stops will be made?");
float stops = Convert.ToInt32(Console.ReadLine()); // prompt user for num of stops
Console.WriteLine("How long will you be stopped for?");
float stopTime = Convert.ToInt32(Console.ReadLine()); // prompt user for stop duration

var RoadTrip = new Trip(miles, speed, stops, stopTime); // create new Trip object using the inputs

Console.WriteLine($"The length of the trip is {RoadTrip.CalculateTime()} hours."); // Tell the user the duration of the trip in hours.

