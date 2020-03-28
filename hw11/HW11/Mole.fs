namespace HW11

type MoleEvent =
  | Popup of Position
  | NothingHappened

type MoleEventStream = seq<MoleEvent>

module MoleEventStream =
  let create (freq: uint32) (seed: int) : MoleEventStream = 
    //let mutable cur = 0u
    Seq.unfold (fun (current: uint32 list)  ->
                        match current.[0] with 
                            |0u -> let next = int((214013UL * uint64(current.[1]) + 2531011UL)%2147483648UL)
                                   //cur <- 1u%freq;
                                   Some(Popup (next%9),[1u%freq;(uint32 next)])
                            |_ ->  
                                   //cur <- (cur+1u)%freq;
                                   Some(NothingHappened,[(current.[0]+1u)%freq ; current.[1]]) ) [0u;(uint32 seed)]
