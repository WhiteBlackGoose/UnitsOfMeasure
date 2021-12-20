namespace UnitsOfMeasure;

public record struct Unit<T, TBase, TNumber>(TNumber Float)
    where TBase : struct, IBaseUnit<TBase, TNumber>
    where T : struct, IBaseUnit<TBase, TNumber>
{
    public override string ToString() => $"{Float} {new T().Postfix}";
}