namespace UnitsOfMeasure;

public readonly record struct Unit<T, TBase, TNumber>(TNumber Float)
    where TBase : struct, IBaseUnit<TBase, TNumber>
    where T : struct, IBaseUnit<TBase, TNumber>
    where TNumber : IMultiplyOperators<TNumber, TNumber, TNumber>, IDivisionOperators<TNumber, TNumber, TNumber>
{
    public override string ToString() => $"{Float:0.00} {new T().Postfix}";

    public Unit<TNew, TBase, TNumber> To<TNew>()
        where TNew : struct, IBaseUnit<TBase, TNumber>
        => new(Float * new T().Base / new TNew().Base);

    /*
    this magic field can improve codegen
    private readonly byte aaa = 3;
    */
}