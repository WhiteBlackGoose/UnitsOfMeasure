namespace UnitsOfMeasure;

public struct Squared<T, TBase, TNumber>
    : IBaseUnit<Squared<TBase, TBase, TNumber>, TNumber>
    where T : struct, IBaseUnit<TBase, TNumber>
    where TBase : struct, IBaseUnit<TBase, TNumber>
    where TNumber : IMultiplyOperators<TNumber, TNumber, TNumber>
{
    public TNumber Base => new T().Base * new T().Base;

    public string Postfix => $"({new T().Postfix})^2";
}

public struct Div<T1, T2, T1Base, T2Base, TNumber>
    : IBaseUnit<Div<T1Base, T2Base, T1Base, T2Base, TNumber>, TNumber>
    where T1Base : struct, IBaseUnit<T1Base, TNumber>
    where T2Base : struct, IBaseUnit<T2Base, TNumber>
    where T1 : struct, IBaseUnit<T1Base, TNumber>
    where T2 : struct, IBaseUnit<T2Base, TNumber>
    where TNumber : IDivisionOperators<TNumber, TNumber, TNumber>
{
    public TNumber Base => new T1().Base / new T2().Base;
    public string Postfix => $"({new T1().Postfix}/{new T2().Postfix})";
}