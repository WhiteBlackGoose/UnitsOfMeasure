namespace UnitsOfMeasure;

public interface IBaseUnit<T, TNumber>
{
    TNumber Base { get; }
    string Postfix { get; }
}