using UnitsOfMeasure;

var angle = 60f.Degrees();
Console.WriteLine(angle);
Console.WriteLine(angle.To(default(Radian<float>)));