namespace UnitsOfMeasure;

public static class Ops
{
    public static Unit<Div<T1, T2, T1Base, T2Base>, Div<T1Base, T2Base, T1Base, T2Base>> Divide<T1, T2, T1Base, T2Base>(this Unit<T1, T1Base> a, Unit<T2, T2Base> b)
         where T1Base : struct, IBaseUnit<T1Base>
             where T2Base : struct, IBaseUnit<T2Base>
         where T1 : struct, IBaseUnit<T1Base>
         where T2 : struct, IBaseUnit<T2Base>
        => new(a.Float / b.Float);

    public static Unit<T1, TBase> Add<T1, T2, TBase>(this Unit<T1, TBase> a, Unit<T2, TBase> b)
        where TBase : struct, IBaseUnit<TBase>
        where T1 : struct, IBaseUnit<TBase>
        where T2 : struct, IBaseUnit<TBase>
        => new((a.Float * new T1().Base + b.Float * new T2().Base) / new T1().Base);

    public static Unit<Squared<T, TBase>, Squared<TBase, TBase>> Square<T, TBase>(this Unit<T, TBase> a)
        where TBase : struct, IBaseUnit<TBase>
        where T : struct, IBaseUnit<TBase>
        => new(a.Float * a.Float);
}