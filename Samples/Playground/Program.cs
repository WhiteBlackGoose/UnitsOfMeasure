using AngouriMath;
using AngouriMath.Extensions;
using UnitsOfMeasure;

var mass1 = "m_1".ToEntity().Kilograms();
var mass2 = "m_2".ToEntity().Kilograms();
var r = "(R - theta)".ToEntity().Meters();

Console.WriteLine(mass1);
Console.WriteLine(mass2);
Console.WriteLine(r);

var formula = mass1.Add(mass2).Divide(r.Square());

Console.WriteLine(formula);