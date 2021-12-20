namespace UnitsOfMeasure;

public struct Meter<TNumber> : IBaseUnit<Meter<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>
{
    public string Postfix => "m";

    public TNumber Base => TNumber.MultiplicativeIdentity;
}

public struct Kilometer<TNumber> : IBaseUnit<Meter<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "km";

    public TNumber Base => Constants<TNumber>.Number1000;
}

public struct Mile<TNumber> : IBaseUnit<Meter<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "mile";

    public TNumber Base => Constants<TNumber>.Number1609_34;
}

