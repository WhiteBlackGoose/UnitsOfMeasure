namespace UnitsOfMeasure;

public struct Second : IBaseUnit<Second>
{
    public string Postfix => "s";

    public float Base => 1;

    public static Unit<Second, Second> From(float a) => new(a);
}

public struct Minute : IBaseUnit<Second>
{
    public string Postfix => "min";

    public float Base => 60;

    public static Unit<Minute, Second> From(float a) => new(a);
}