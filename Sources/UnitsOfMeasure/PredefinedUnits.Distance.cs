
namespace UnitsOfMeasure;

public struct Meter : IBaseUnit<Meter>
{
    public string Postfix => "m";

    public float Base => 1;

    public static Unit<Meter, Meter> From(float a) => new(a);
}

public struct Kilometer : IBaseUnit<Meter>
{
    public string Postfix => "km";

    public float Base => 1000;

    public static Unit<Kilometer, Meter> From(float a) => new(a);
}

public struct Mile : IBaseUnit<Meter>
{
    public string Postfix => "mile";

    public float Base => 1600;

    public static Unit<Mile, Meter> From(float a) => new(a);
}

