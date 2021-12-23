using System.Globalization;

namespace UnitsOfMeasure;

internal static class Constants<TNumber>
    where TNumber : IParseable<TNumber>
{
    internal static readonly TNumber Number1000;
    internal static readonly TNumber Number0_1;
    internal static readonly TNumber Number0_01;
    internal static readonly TNumber Number0_001;
    internal static readonly TNumber Number0_000001;
    internal static readonly TNumber Number1609_34;
    internal static readonly TNumber Number60;
    internal static readonly TNumber Number3600;
    internal static readonly TNumber Number0_0174;

    static TNumber FromString(string forFloat, string forInt)
    {
        var isFloating = typeof(TNumber) == typeof(float) || typeof(TNumber) == typeof(double) || typeof(TNumber) == typeof(System.Numerics.Complex);
        return isFloating
                ? TNumber.Parse(forFloat, CultureInfo.InvariantCulture)
                : TNumber.Parse(forInt, null);
    }

    static Constants()
    {
        Number1000 = TNumber.Parse("1000", null);
        Number1609_34 = FromString("1609.34", "1609");
        Number60 = TNumber.Parse("60", null);
        Number3600 = TNumber.Parse("3600", null);
        Number0_0174 = FromString("0.0174", "0");
        Number0_1 = FromString("0.1", "0");
        Number0_01 = FromString("0.01", "0");
        Number0_001 = FromString("0.001", "0");
        Number0_000001 = FromString("0.000001", "0");
    }
}