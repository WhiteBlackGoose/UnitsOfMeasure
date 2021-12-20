using System.Globalization;

namespace UnitsOfMeasure;

internal static class Constants<TNumber>
    where TNumber : IParseable<TNumber>
{
    internal static readonly TNumber Number1000;
    internal static readonly TNumber Number1609_34;
    internal static readonly TNumber Number60;

    static Constants()
    {
        Number1000 = TNumber.Parse("1000", null);
        if (typeof(TNumber) == typeof(float) || typeof(TNumber) == typeof(double) || typeof(TNumber) == typeof(System.Numerics.Complex))
            Number1609_34 = TNumber.Parse("1609.34", CultureInfo.InvariantCulture);
        else
            Number1609_34 = TNumber.Parse("1609", null);
        Number60 = TNumber.Parse("60", null);
    }
}