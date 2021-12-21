using System.Globalization;

namespace UnitsOfMeasure;

internal static class Constants<TNumber>
    where TNumber : IParseable<TNumber>
{
    internal static readonly TNumber Number1000;
    internal static readonly TNumber Number1609_34;
    internal static readonly TNumber Number60;
    internal static readonly TNumber Number0_0174;

    static Constants()
    {
        var isFloating = typeof(TNumber) == typeof(float) || typeof(TNumber) == typeof(double) || typeof(TNumber) == typeof(System.Numerics.Complex);
        Number1000 = TNumber.Parse("1000", null);
        if (isFloating)
            Number1609_34 = TNumber.Parse("1609.34", CultureInfo.InvariantCulture);
        else
            Number1609_34 = TNumber.Parse("1609", null);
        Number60 = TNumber.Parse("60", null);
        Number0_0174 = isFloating ? TNumber.Parse("0.0174", CultureInfo.InvariantCulture) : TNumber.Parse("0", null);
    }
}