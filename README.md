# Units Of Measure

Conceptual repo. Most advanced compile time safe units of measure for C#.

Based on generic type safety, type argument inference, generic math.

## Examples

### C#

```cs
var distance = 5f.Meters();                                    // 5.00 m
var time = 4f.Seconds();                                       // 4.00 s
var speed = distance.Divide(time);                             // 1.25 (m/s)
var additionalSpeed = 1f.Kilometers().Divide(60f.Minutes());   // 0.02 (km/min)
var totalSpeed = speed.Add(additionalSpeed);                   // 1.53 (m/s)
var bla = distance.Add(time);                                  // compilation error, you can't add time and distance
```

### F#

In F# we additionally get generic operators.
```cs
var distance = 5f.Meters();                              // 5.00 m
var time = 4f.Seconds();                                 // 4.00 s
var speed = distance / time;                             // 1.25 (m/s)
var additionalSpeed = 1f.Kilometers() / 60f.Minutes();   // 0.02 (km/min)
var totalSpeed = speed + additionalSpeed;                // 1.53 (m/s)
var bla = distance + time;                               // compilation error, you can't add time and distance
```

## How does this work?

### General structure

Your value is stored in `Unit` with three type arguments. A one which corresponds to the unit of your value. A one which is this unit's base value (e. g. for kilometers it would normally be meter). And a one which is your type's number (float/double/int etc.).

Operations are defined as extension methods in UoM as well as regular operators in the F# version. Each operation will
1) Return a combination of units. For example, division of kilometer and second returns `Divide<Kilometer, Second, ...>`.
2) Return the instance's type. This normally happens on persistent operations, like addition, which does not change the type.
3) Fail to compile. This happens for persistent operations on incompatible types. For example, addition of seconds and kilometers.

### Lengths, masses, speeds...?

None of it. The core idea is that each unit of measure has its base type. E. g. for kilometer it is meter, for gram it is kilogram, for meter it is meter too.

### Conversion

Thanks to the base type idea, one can easily convert units with the same base type. Each type holds how many times it is bigger than its base type. For kilometer it would be 1000, for mile around 1600, for gram it will be 0.001. Arithmetic types, like division or square, would combine those values into their own bases. For example, square kilometer would hold 1'000'000 square meters.

Based on this, we can easily convert a value of type A to type B assuming they share the same base unit.

### Generic math

.NET 6 introduces preview feature: generic math. To make the UoM even more customizable, it supports generic math too, so every single value is some generic `TNumber` constrained as little as possible to allow the necessary operations.

## Efficiency

It is far from `float`s. Despite that there is no runtime dispatch, everything is inlined, there is still overhead. The thing is,
floats are passed and returned by `xmm` registers, so operations on them do not invole memory.

However, since `Unit` wraps a float, it is passed by an "integer" register. It then is being written to RAM (stack), 
after which it is loaded onto an `xmm` register, an operation is then performed, and written back to memory, and then 
unloaded back to a regular "integer" register.

Consider a simple function which calculates something looking similar to gravity force.

Performance:

| Method |     Mean |     Error |    StdDev |
|------- |---------:|----------:|----------:|
| Floats | 1.555 ns | 0.0734 ns | 0.1855 ns |
|    UoM | 5.691 ns | 0.1553 ns | 0.3441 ns |

#### For floats:

```cs
public static float ComputeGravityForceFloats(float mass1, float mass2, float distance)
{
    return (mass1 + mass2) / (distance * distance);
}
```

The codegen:
```assembly
    00007FFBAB3A64B0 C5F877               vzeroupper
    00007FFBAB3A64B3 C5FA58C1             vaddss    xmm0,xmm0,xmm1
    00007FFBAB3A64B7 C5EA59CA             vmulss    xmm1,xmm2,xmm2
    00007FFBAB3A64BB C5FA5EC1             vdivss    xmm0,xmm0,xmm1
    00007FFBAB3A64BF C3                   ret
```

#### For UoMs:

```cs
public static Force ComputeGravityForceUoM(Mass mass1, Mass mass2, Length distance)
{
    return mass1.Add(mass2).Divide(distance.Square());
}
```

(`Mass`, `Length` and `Force` are no more than aliases made with `using`)

The codegen:
```assembly
    00007FFBAB3B44C0 4883EC48             sub       rsp,48h
    00007FFBAB3B44C4 C5F877               vzeroupper
    00007FFBAB3B44C7 894C2440             mov       [rsp+40h],ecx
    00007FFBAB3B44CB 89542438             mov       [rsp+38h],edx
    00007FFBAB3B44CF C5FA10442440         vmovss    xmm0,[rsp+40h]
    00007FFBAB3B44D5 C5FA104C2438         vmovss    xmm1,[rsp+38h]
    00007FFBAB3B44DB C5FA58C1             vaddss    xmm0,xmm0,xmm1
    00007FFBAB3B44DF C5FA11442430         vmovss    [rsp+30h],xmm0
    00007FFBAB3B44E5 4489442428           mov       [rsp+28h],r8d
    00007FFBAB3B44EA C5FA10442428         vmovss    xmm0,[rsp+28h]
    00007FFBAB3B44F0 C5FA59C0             vmulss    xmm0,xmm0,xmm0
    00007FFBAB3B44F4 C5FA11442420         vmovss    [rsp+20h],xmm0
    00007FFBAB3B44FA 8B442430             mov       eax,[rsp+30h]
    00007FFBAB3B44FE 89442418             mov       [rsp+18h],eax
    00007FFBAB3B4502 8B442420             mov       eax,[rsp+20h]
    00007FFBAB3B4506 89442410             mov       [rsp+10h],eax
    00007FFBAB3B450A C5FA10442418         vmovss    xmm0,[rsp+18h]
    00007FFBAB3B4510 C5FA104C2410         vmovss    xmm1,[rsp+10h]
    00007FFBAB3B4516 C5FA5EC1             vdivss    xmm0,xmm0,xmm1
    00007FFBAB3B451A C5FA11442408         vmovss    [rsp+8],xmm0
    00007FFBAB3B4520 8B442408             mov       eax,[rsp+8]
    00007FFBAB3B4524 4883C448             add       rsp,48h
    00007FFBAB3B4528 C3                   ret
```

## Other solutions?

Let's compare to UnitsNet and F#'s UoMs.

| Criterion             | Goose's UoMs | F#'s UoMs | UnitsNet |
|:---------------------:|:------------:|:---------:|:--------:|
| Interop             | 🥇 | 🥈 | 🥇 |
| Speed               | 🥈 | 🥇 | 🥉 |
| Ext. of dimensions  | 🥇 | 🥇 | 🥈 |
| Ext. of units       | 🥇 | 🥇 | 🥈 |
| Compile time safety | 🥇 | 🥇 | 🥇 |
| Custom numeric type | 🥇 | 🥈 | 🥉 |
| No runtime dispatch | 🥇 | 🥇 | 🥈 |
| Syntax              | 🥉 | 🥇 | 🥈 |
| Type conversions    | 🥇 | 🥈 | 🥇 |
| API richness        | 🥈 | 🥉 | 🥇 |

\*Ext. is extendability (able to extend the built-in things). Extendability of units means you can add more units. Extendability of dimensions means you can add "dimensions" (e. g. length, mass, etc.).
