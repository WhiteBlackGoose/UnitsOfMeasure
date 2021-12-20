namespace UnitsOfMeasure;

public interface IBaseUnit<T>// : IUnit where T : IUnit
{
    float Base { get; }

    string Postfix { get; }
}