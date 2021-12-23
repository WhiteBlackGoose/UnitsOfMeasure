namespace UnitsOfMeasure;

public struct Second<TNumber> : IBaseUnit<Second<TNumber>, TNumber>
    where TNumber : IMultiplicativeIdentity<TNumber, TNumber>
{
    public string Postfix => "s";

    public TNumber Base => TNumber.MultiplicativeIdentity;
}

public struct Millisecond<TNumber> : IBaseUnit<Second<TNumber>, TNumber> where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "ms";
    public TNumber Base => Constants<TNumber>.Number0_001;
}

public struct Minute<TNumber> : IBaseUnit<Second<TNumber>, TNumber> where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "min";
    public TNumber Base => Constants<TNumber>.Number60;
}

public struct Hour<TNumber> : IBaseUnit<Second<TNumber>, TNumber> where TNumber : IMultiplicativeIdentity<TNumber, TNumber>, IParseable<TNumber>
{
    public string Postfix => "hr";
    public TNumber Base => Constants<TNumber>.Number3600;
}