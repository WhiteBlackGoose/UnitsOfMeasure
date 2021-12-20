namespace UnitsOfMeasure;

public record struct Unit<T, TBase>(float Float)
    where TBase : struct, IBaseUnit<TBase>
    where T : struct, IBaseUnit<TBase>
{
    public override string ToString() => $"{Float} {new T().Postfix}";
}