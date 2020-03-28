module HW10.BoardHelper
let cvt st = match st with
                | " " -> 0
                | "O" -> 1
                | "X" -> -1
                | _ -> failwith "Wrong input"
let change st = match st with 
                    | "O" -> O
                    | "X" -> X
                    | _ -> failwith "Wrong input"
let cvt2 st = match st with
                | " " -> 0
                | _ -> 1
let isOver sum = 
    sum=3 || sum= -3
let checkWinner (states:SlotState []) =
    let s1 = cvt (SlotState.toString states.[0])
    let s2 = cvt (SlotState.toString states.[1])
    let s3 = cvt (SlotState.toString states.[2])
    let s4 = cvt (SlotState.toString states.[3])
    let s5 = cvt (SlotState.toString states.[4])
    let s6 = cvt (SlotState.toString states.[5])
    let s7 = cvt (SlotState.toString states.[6])
    let s8 = cvt (SlotState.toString states.[7])
    let s9 = cvt (SlotState.toString states.[8])
    if isOver (s1+s2+s3) || isOver (s1+s4+s7) then Some (change (SlotState.toString states.[0]))
    elif isOver (s9+s8+s7) || isOver (s9+s6+s3) then Some (change (SlotState.toString states.[8]))
    elif isOver (s1+s5+s9) || isOver (s2+s5+s8) || isOver (s3+s5+s7) || isOver (s4+s5+s6) then Some (change (SlotState.toString states.[4]))
    else None

let isDraw (states:SlotState []) =
    let s1 = cvt2 (SlotState.toString states.[0])
    let s2 = cvt2 (SlotState.toString states.[1])
    let s3 = cvt2 (SlotState.toString states.[2])
    let s4 = cvt2 (SlotState.toString states.[3])
    let s5 = cvt2 (SlotState.toString states.[4])
    let s6 = cvt2 (SlotState.toString states.[5])
    let s7 = cvt2 (SlotState.toString states.[6])
    let s8 = cvt2 (SlotState.toString states.[7])
    let s9 = cvt2 (SlotState.toString states.[8])
    match checkWinner states with
        | None -> s1+s2+s3+s4+s5+s6+s7+s8+s9=9
        | _ -> false
