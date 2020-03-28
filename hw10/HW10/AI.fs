namespace HW10

/// Tic-tac-toe AI.
[<AbstractClass>]
type AI () =
  abstract member NextMove: player: Marker -> board: Board -> int

/// Random strategy.
type RandomStrategy () =
  inherit AI ()
  let r = System.Random ()
  override __.NextMove _player board =
    let rec loop () =
      let idx = r.Next (1, 10) // randomly pick [1, 9]
      if board.IsOccupied idx then loop ()
      else idx
    loop ()

