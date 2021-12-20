module UnitsOfMeasure

open UnitsOfMeasure

(*
type Unit<'T, 'TBase, 'TNumber
    when 'TBase :> IBaseUnit<'TBase, 'TNumber>
    and 'TBase : struct
    and 'T :> IBaseUnit<'TBase, 'TNumber>
    and 'T : struct
    > with

    static member Aaa () = 4

    // static member (+) (a, b) =
    //     Ops.Add(a, b)
    *)

// type BlaBla =
//     static member (+) (a, b) =
//         Ops.Add(a, b)

let (+) a b = Ops.Add(a, b)

let (/) a b = Ops.Divide(a, b)