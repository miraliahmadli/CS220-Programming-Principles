namespace HW10

/// Minimax strategy.
type MinimaxStrategy () =
  inherit AI ()
  override __.NextMove player board =
    let rec MiniMax (pl: Marker) (brd: Board) =
        match brd.CheckWinner() with 
            | Some x -> (1,-1)
            | None -> 
                if brd.IsDraw() then (1,0)
                else 
                    let rec chk cur (board: Board) pl move score=
                        if cur=10 then (move,score)
                        elif (board.IsOccupied cur)=false then
                            let newb = board.Copy()
                            newb.Mark cur pl |> ignore
                            let (newm,newsc) = (MiniMax (Marker.getOpponent pl) newb)
                            if -newsc > score then 
                                chk (cur+1) board pl cur (-newsc)
                            else chk (cur+1) board pl move score
                        else chk (cur+1) board pl move score
                    chk 1 brd pl 1 -2
    fst (MiniMax player board) 


