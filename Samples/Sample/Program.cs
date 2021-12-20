using UnitsOfMeasure;

var distance = Meter.From(5);
Console.WriteLine($"Distance: {distance}");
var time = Second.From(4);
Console.WriteLine($"Time: {time}");
var speed = Ops.Divide(distance, time);
Console.WriteLine($"Speed: {speed}");

var anotherDistance = Kilometer.From(0.3f);
Console.WriteLine($"Another distance: {anotherDistance}");
Console.WriteLine($"Total distance: {Ops.Add<Meter, Kilometer, Meter>(distance, anotherDistance)}");

var speed1 = Meter.From(20).Divide(Second.From(1));
Console.WriteLine($"Speed 1: {speed1}");
var speed2 = Kilometer.From(5).Divide(Minute.From(1));
Console.WriteLine($"Speed 2: {speed2}");
var added = speed1.Add(speed2);
Console.WriteLine($"Their sum: {added}");

var sideOfHouse1 = Meter.From(200);
var sideOfHouse2 = Kilometer.From(0.5f);
Console.WriteLine($"Side size of house 1: {sideOfHouse1}");
Console.WriteLine($"Side size of house 2: {sideOfHouse2}");
var area1 = sideOfHouse1.Square();
var area2 = sideOfHouse2.Square();
Console.WriteLine($"Area of house 1: {area1}");
Console.WriteLine($"Area of house 2: {area2}");
var totalArea = area1.Add(area2);
Console.WriteLine($"Total area: {totalArea}");
var outerHouse = Mile.From(0.35f).Square();
var areaOf2and3 = area2.Add(outerHouse);
Console.WriteLine($"Area of 2nd and 3rd house: {areaOf2and3}");
var areaOf2and3rev = outerHouse.Add(area2);
Console.WriteLine($"Area of 2nd and 3rd house in miles: {areaOf2and3rev}");