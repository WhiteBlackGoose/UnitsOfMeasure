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
