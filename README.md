# Units Of Measure

Conceptual repo. Most advanced compile time safe units of measure for C#.

Based on generic type safety, type argument inference, generic math.

### C#

```cs
var distance = 5f.Meters();                                    // 5.00 m
var time = 4f.Seconds();                                       // 4.00 s
var speed = distance.Divide(time);                             // 1.25 (m/s)
var additionalSpeed = 1f.Kilometers().Divide(60f.Minutes());   // 0.02 (km/min)
var totalSpeed = speed.Add(additionalSpeed);                   // 1.53 (m/s)
var bla = distance.Add(time);                                  // compilation error, you can't add time and distance
```
