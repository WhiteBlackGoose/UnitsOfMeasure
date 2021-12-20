namespace UnitsOfMeasure;

public struct Squared<T, TBase>
    : IBaseUnit<Squared<TBase, TBase>>
    where T : struct, IBaseUnit<TBase>
    where TBase : struct, IBaseUnit<TBase>
{
    public float Base => new T().Base * new T().Base;

    public string Postfix => $"({new T().Postfix})^2";
}

public struct Div<T1, T2, T1Base, T2Base>
    : IBaseUnit<Div<T1Base, T2Base, T1Base, T2Base>>
    where T1Base : struct, IBaseUnit<T1Base>
    where T2Base : struct, IBaseUnit<T2Base>
    where T1 : struct, IBaseUnit<T1Base>
    where T2 : struct, IBaseUnit<T2Base>
{
    public float Base => new T1().Base / new T2().Base;

    public string Postfix => $"({new T1().Postfix}/{new T2().Postfix})";
}