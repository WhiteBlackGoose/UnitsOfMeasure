using UnitsOfMeasure;

var distance = 5f.Meters();                                    // meters
Console.WriteLine(distance);
var time = 4f.Seconds();                                       // seconds
Console.WriteLine(time);
var speed = distance.Divide(time);                             // meters per second
Console.WriteLine(speed);
var additionalSpeed = 1f.Kilometers().Divide(60f.Minutes());   // km per minute
Console.WriteLine(additionalSpeed);
var totalSpeed = speed.Add(additionalSpeed);                   // meters per second
Console.WriteLine(totalSpeed);