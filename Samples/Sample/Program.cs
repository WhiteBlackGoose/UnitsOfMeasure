using AngouriMath.Extensions;
using UnitsOfMeasure;
using static UnitsOfMeasure.UoM;

Console.WriteLine($"Naive case\n{new string('-', 20)}");
var distance = 5f.Meters();
Console.WriteLine($"Distance: {distance}");
var time = 4f.Seconds();
Console.WriteLine($"Time: {time}");
var speed = distance.Divide(time);
Console.WriteLine($"Speed: {speed}");

Console.WriteLine($"\nLinear conversions\n{new string('-', 20)}");

var anotherDistance = UoM.Kilometers(0.3f);
Console.WriteLine($"Another distance: {anotherDistance}");
Console.WriteLine($"Total distance: {distance.Add(anotherDistance)}");

Console.WriteLine($"\nMore complex conversions\n{new string('-', 20)}");

var speed1 = 20.0.Meters().Divide(1.0.Seconds());
Console.WriteLine($"Speed 1: {speed1}");
var speed2 = 5.0.Kilometers().Divide(1.0.Minutes());
Console.WriteLine($"Speed 2: {speed2}");
var added = speed1.Add(speed2);
Console.WriteLine($"Their sum: {added}");

var area1 = 0.3.Kilometers().Square();
var area2 = 0.2.Miles().Square();
Console.WriteLine($"Area 1: {area1}");
Console.WriteLine($"Area 2: {area2}");
Console.WriteLine($"Total area: {area1.Add(area2)}");

Console.WriteLine($"\nSymbolic algebra formulas\n{new string('-', 20)}");

var mass1 = "m_1".ToEntity().Kilograms();
var mass2 = "m_2".ToEntity().Kilograms();
var r = "(R - theta)".ToEntity().Meters();

Console.WriteLine($"Mass1: {mass1}");
Console.WriteLine($"Mass2: {mass2}");
Console.WriteLine($"Radius: {r}");

var formula = mass1.Add(mass2).Divide(r.Square());

Console.WriteLine($"Gravity force or something: {formula}");