open UnitsOfMeasure

let a = 550f.Meters()
let b = 3f.Kilometers()
let c = a + b
printfn $"Total distance: {a + b}"

let distance = 100f.Meters()
let time = 2f.Seconds()
let speed = distance / time
printfn $"Distance: {distance}"
printfn $"Time: {time}"
printfn $"Speed: {speed}"
let totalSpeed = speed + 1f.Kilometers() / 60f.Minutes()
printfn $"Speed + 1km/h: {totalSpeed}"
