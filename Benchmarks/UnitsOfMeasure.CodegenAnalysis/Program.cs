using CodegenAnalysis.Benchmarks;
using System.Runtime.CompilerServices;
using UnitsOfMeasure;
using Length = UnitsOfMeasure.Unit<UnitsOfMeasure.Meter<float>, UnitsOfMeasure.Meter<float>, float>;
using Mass = UnitsOfMeasure.Unit<UnitsOfMeasure.Kilogram<float>, UnitsOfMeasure.Kilogram<float>, float>;
using Area = UnitsOfMeasure.Unit<
                UnitsOfMeasure.Squared<UnitsOfMeasure.Meter<float>, UnitsOfMeasure.Meter<float>, float>, 
                UnitsOfMeasure.Squared<UnitsOfMeasure.Meter<float>, UnitsOfMeasure.Meter<float>, float>, 
                float>;
using Force = UnitsOfMeasure.Unit<
                UnitsOfMeasure.Div<
                    UnitsOfMeasure.Kilogram<float>,
                    UnitsOfMeasure.Squared<UnitsOfMeasure.Meter<float>, UnitsOfMeasure.Meter<float>, float>,
                    UnitsOfMeasure.Kilogram<float>,
                    UnitsOfMeasure.Squared<UnitsOfMeasure.Meter<float>, UnitsOfMeasure.Meter<float>, float>,
                float>,
                UnitsOfMeasure.Div<
                    UnitsOfMeasure.Kilogram<float>,
                    UnitsOfMeasure.Squared<UnitsOfMeasure.Meter<float>, UnitsOfMeasure.Meter<float>, float>,
                    UnitsOfMeasure.Kilogram<float>,
                    UnitsOfMeasure.Squared<UnitsOfMeasure.Meter<float>, UnitsOfMeasure.Meter<float>, float>,
                float>,
                float>;

unsafe
{
    Console.WriteLine(sizeof(Unit<Meter<float>, Meter<float>, float>));
}
CodegenBenchmarkRunner.Run<Bench>();

public class Bench
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit<Meter<float>, Meter<float>, float> AddFromFloats(float a, float b)
    {
        return a.Meters().Add(b.Meters());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit<Meter<float>, Meter<float>, float> Add(Unit<Meter<float>, Meter<float>, float> a, Unit<Meter<float>, Meter<float>, float> b)
    {
        return a.Add(b);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float AddFloats(float a, float b)
    {
        return a + b;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float ComputeGravityForceFloats(float mass1, float mass2, float distance)
    {
        return (mass1 + mass2) / (distance * distance);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Force ComputeGravityForceUoM(Mass mass1, Mass mass2, Length distance)
    {
        return mass1.Add(mass2).Divide(distance.Square());
    }

    [CAAnalyze]
    [CASubject(typeof(Bench), "ComputeGravityForceFloats")]
    public static void Floats()
    {
        ComputeGravityForceFloats(5f, 10f, 10f);
    }

    [CAAnalyze]
    [CASubject(typeof(Bench), "ComputeGravityForceUoM")]
    public static void UoM()
    {
        ComputeGravityForceUoM(5f.Kilograms(), 10f.Kilograms(), 10f.Meters());
    }

    /*
    [CAAnalyze]
    [CASubject(typeof(Bench), "Add")]
    public static void DoUoM()
    {
        Add(5f.Meters(), 10f.Meters());
    }

    [CAAnalyze]
    [CASubject(typeof(Bench), "AddFromFloats")]
    public static void DoUoMFromFloats()
    {
        AddFromFloats(5f, 10f);
    }

    [CAAnalyze]
    [CASubject(typeof(Bench), "AddFloats")]
    public static void DoFloats()
    {
        AddFloats(5f, 10f);
    }*/
}