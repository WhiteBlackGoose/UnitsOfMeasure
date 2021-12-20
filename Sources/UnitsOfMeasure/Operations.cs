namespace UnitsOfMeasure;

public static class Ops
{
    public static Unit<Div<T1, T2, T1Base, T2Base, TNumber>, Div<T1Base, T2Base, T1Base, T2Base, TNumber>, TNumber> 
         Divide<T1, T2, T1Base, T2Base, TNumber>(this Unit<T1, T1Base, TNumber> a, Unit<T2, T2Base, TNumber> b)
         where T1Base : struct, IBaseUnit<T1Base, TNumber>
         where T2Base : struct, IBaseUnit<T2Base, TNumber>
         where T1 : struct, IBaseUnit<T1Base, TNumber>
         where T2 : struct, IBaseUnit<T2Base, TNumber>
         where TNumber : IDivisionOperators<TNumber, TNumber, TNumber>
        => new(a.Float / b.Float);

    public static Unit<T1, TBase, TNumber> 
        Add<T1, T2, TBase, TNumber>(this Unit<T1, TBase, TNumber> a, Unit<T2, TBase, TNumber> b)
        where TBase : struct, IBaseUnit<TBase, TNumber>
        where T1 : struct, IBaseUnit<TBase, TNumber>
        where T2 : struct, IBaseUnit<TBase, TNumber>
        where TNumber : IDivisionOperators<TNumber, TNumber, TNumber>, 
            IAdditionOperators<TNumber, TNumber, TNumber>, 
            IMultiplyOperators<TNumber, TNumber, TNumber>
        => new((a.Float * new T1().Base + b.Float * new T2().Base) / new T1().Base);

    public static Unit<Squared<T, TBase, TNumber>, Squared<TBase, TBase, TNumber>, TNumber>
        Square<T, TBase, TNumber>(this Unit<T, TBase, TNumber> a)
        where TBase : struct, IBaseUnit<TBase, TNumber>
        where T : struct, IBaseUnit<TBase, TNumber>
        where TNumber : IMultiplyOperators<TNumber, TNumber, TNumber>
        => new(a.Float * a.Float);
}