using AngouriMath;
using AngouriMath.Extensions;
using UnitsNet;
using UnitsOfMeasure;

var a = Length.FromMeters(550);
var b = Length.FromKilometers(1);
var c = Mass.FromKilograms(10);
Console.WriteLine(a + b);


/*
var m1 = "m_1".ToEntity().Kilograms();
var m2 = "m_2".ToEntity().Tonns();
var totalMass = m1.Add(m2);
Console.WriteLine($"Total mass: {totalMass}");
var r = "R - sqrt(r)".ToEntity().Meters();
Console.WriteLine($"Distance: {r}");
var r2 = r.Square();
var F = totalMass.Divide(r2);
Console.WriteLine($"Gravity: {F}");
*/


/*
var distance1 = 100f.Meters();
var time1 = 20f.Seconds();
Console.WriteLine($"Distance 1: {distance1}");
Console.WriteLine($"Time 1: {time1}");
var speed1 = distance1.Divide(time1);;
var speed2 = 50f.Kilometers().Divide(30f.Minutes());
Console.WriteLine($"Speed 1: {speed1}");
Console.WriteLine($"Speed 2: {speed2}");
var totalSpeed = speed1.Add(speed2);
Console.WriteLine($"Total speed: {totalSpeed}");
var acc1 = speed1.Divide(3f.Minutes());
var acc2 = speed2.Divide(80f.Seconds());
Console.WriteLine($"Acceleration 1: {acc1}");
Console.WriteLine($"Acceleration 2: {acc2}");
var totalAcceleration = acc1.Add(acc2);
Console.WriteLine($"Total acceleration: {totalAcceleration}");
var area = 20.0.Meters().Square();
var anotherArea = 0.1.Miles().Square();
Console.WriteLine($"Area 1: {area}");
Console.WriteLine($"Area 2: {anotherArea}");
Console.WriteLine($"Total area: {area.Add(anotherArea)}");

*/










/*
var a = 550f.Meters();

// makes sense!
var b = a.To<Kilometer<float>>();

// doesn't make sense :(
var c = a.To<Second<float>>();*/