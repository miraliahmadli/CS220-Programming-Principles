namespace HW11

type Position = int

type PositionStream = seq<Position>

module PositionStream =
  let create seed = 
    Seq.unfold (fun current -> 
                    let next = int((214013UL * uint64(current) + 2531011UL)%2147483648UL)
                    Some(next%9,next)) seed
