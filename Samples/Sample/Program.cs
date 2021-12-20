using UnitsOfMeasure;
using static UnitsOfMeasure.UoM;

var distance = 5f.Meters();
Console.WriteLine($"Distance: {distance}");
var time = 4f.Seconds();
Console.WriteLine($"Time: {time}");
var speed = Ops.Divide(distance, time);
Console.WriteLine($"Speed: {speed}");

var anotherDistance = UoM.Kilometers(0.3f);
Console.WriteLine($"Another distance: {anotherDistance}");
Console.WriteLine($"Total distance: {distance.Add(anotherDistance)}");

var speed1 = 20.0.Meters().Divide(1.0.Seconds());
Console.WriteLine($"Speed 1: {speed1}");
var speed2 = 5.0.Kilometers().Divide(1.0.Minutes());
Console.WriteLine($"Speed 2: {speed2}");
var added = speed1.Add(speed2);
Console.WriteLine($"Their sum: {added}");

var sideOfHouse1 = 200.0.Meters();
var sideOfHouse2 = 0.5.Kilometers();
Console.WriteLine($"Side size of house 1: {sideOfHouse1}");
Console.WriteLine($"Side size of house 2: {sideOfHouse2}");
var area1 = sideOfHouse1.Square();
var area2 = sideOfHouse2.Square();
Console.WriteLine($"Area of house 1: {area1}");
Console.WriteLine($"Area of house 2: {area2}");
var totalArea = area1.Add(area2);
Console.WriteLine($"Total area: {totalArea}");
var outerHouse = 0.35.Miles().Square();
var areaOf2and3 = area2.Add(outerHouse);
Console.WriteLine($"Area of 2nd and 3rd house: {areaOf2and3}");
var areaOf2and3rev = outerHouse.Add(area2);
Console.WriteLine($"Area of 2nd and 3rd house in miles: {areaOf2and3rev}");