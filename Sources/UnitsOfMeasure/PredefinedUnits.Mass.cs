namespace UnitsOfMeasure;

public struct Kilogram<TNumber> : IBaseUnit<Kilogram<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>
{
    public string Postfix => "kg";

    public TNumber Base => TNumber.MultiplicativeIdentity;
}

public struct Tonn<TNumber> : IBaseUnit<Kilogram<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "t";

    public TNumber Base => Constants<TNumber>.Number1000;
}

public struct Gram<TNumber> : IBaseUnit<Kilogram<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "g";

    public TNumber Base => Constants<TNumber>.Number0_001;
}

public struct Milligram<TNumber> : IBaseUnit<Kilogram<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "mg";

    public TNumber Base => Constants<TNumber>.Number0_000001;
}