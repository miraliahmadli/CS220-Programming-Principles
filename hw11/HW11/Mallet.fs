namespace HW11

type MalletEvent =
  | Hit of Position

type MalletEventStream = seq<MalletEvent>

module MalletEventStream =
  let create (seed: int) : MalletEventStream = 
    Seq.unfold (fun current -> 
                    let next = int((214013UL * uint64(current) + 2531011UL)%2147483648UL)
                    Some(Hit (next%9),next)) seed
