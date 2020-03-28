namespace HW10.Tests

open HW10

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =
  let toBoard m =
    let board = new Board ()
    let iterAux i = function
      | Marked m -> board.Mark (i + 1) m |> ignore | EmptySlot -> ()
    Array.iteri iterAux m
    board

  [<TestMethod; Timeout(10000)>]
  member __.``checkWinnerTest 1``() =
    Assert.AreEqual(None,
      [| EmptySlot; EmptySlot; EmptySlot
         EmptySlot; EmptySlot; EmptySlot
         EmptySlot; EmptySlot; EmptySlot |]
      |> BoardHelper.checkWinner)

  [<TestMethod; Timeout(10000)>]
  member __.``checkWinnerTest 2``() =
    Assert.AreEqual(Some O,
      [| Marked O;  Marked O;  Marked O
         Marked X;  Marked X;  EmptySlot
         EmptySlot; EmptySlot; EmptySlot |]
      |> BoardHelper.checkWinner)

  [<TestMethod; Timeout(10000)>]
  member __.``IsDrawTest``() =
    [| Marked O; Marked X; Marked O
       Marked X; Marked O; Marked X
       Marked X; Marked O; Marked X |]
    |> BoardHelper.isDraw |> Assert.IsTrue


  // checkWinner Tests
  [<TestMethod; Timeout(10000)>]
  member __.``checkWinner. Normal Case2``() =
    Assert.AreEqual(Some O,
      [| Marked O;  Marked X;  Marked O
         Marked O;  Marked O;  Marked X
         Marked O;  Marked X;  Marked X |]
      |> BoardHelper.checkWinner)

  [<TestMethod; Timeout(10000)>]
  member __.``checkWinner. Normal Case3``() =
    Assert.AreEqual(Some O,
      [| Marked X; Marked X ;  Marked O
         Marked X; EmptySlot;  Marked O
         Marked O; Marked X ;  Marked O |]
      |> BoardHelper.checkWinner)

  [<TestMethod; Timeout(10000)>]
  member __.``checkWinner. Normal Case4``() =
    Assert.AreEqual(Some X,
      [| Marked O;  Marked X;  Marked O
         Marked X;  Marked X;  Marked O
         Marked O;  Marked X;  Marked X |]
      |> BoardHelper.checkWinner)

  [<TestMethod; Timeout(10000)>]
  member __.``checkWinner. Normal Case5``() =
    Assert.AreEqual(Some X,
      [| Marked O;  Marked O;  Marked X
         Marked X;  Marked X;  Marked O
         Marked X;  Marked X;  Marked O |]
      |> BoardHelper.checkWinner)

  [<TestMethod; Timeout(10000)>]
  member __.``checkWinner. Normal Case6``() =
    Assert.AreEqual(Some X,
      [| Marked O; Marked O ;  Marked X
         Marked O; Marked X ;  EmptySlot
         Marked X; EmptySlot;  EmptySlot |]
      |> BoardHelper.checkWinner)



  // isDraw Tests
  [<TestMethod; Timeout(10000)>]
  member __.``isDraw. Normal Case1``() =
    [| Marked X; Marked O; Marked X
       Marked O; Marked X; Marked O
       Marked X; Marked O; Marked X |]
    |> BoardHelper.isDraw |> Assert.IsFalse

  [<TestMethod; Timeout(10000)>]
  member __.``isDraw. Normal Case2``() =
    [| Marked X; Marked O; Marked O
       Marked O; Marked X; Marked X
       Marked X; Marked O; Marked O |]
    |> BoardHelper.isDraw |> Assert.IsTrue

  [<TestMethod; Timeout(10000)>]
  member __.``isDraw. Normal Case3``() =
    [| Marked O; Marked X; Marked O
       Marked X; Marked O; Marked X
       Marked X; Marked O; Marked X |]
    |> BoardHelper.isDraw |> Assert.IsTrue

  [<TestMethod; Timeout(10000)>]
  member __.``isDraw. Normal Case4``() =
    [| EmptySlot; EmptySlot; EmptySlot
       EmptySlot; EmptySlot; EmptySlot
       EmptySlot; EmptySlot; EmptySlot |]
    |> BoardHelper.isDraw |> Assert.IsFalse

  [<TestMethod; Timeout(10000)>]
  member __.``isDraw. Normal Case5``() =
    [| Marked O; Marked X; EmptySlot
       Marked X; Marked O; Marked X
       Marked X; Marked O; Marked X |]
    |> BoardHelper.isDraw |> Assert.IsFalse

  [<TestMethod; Timeout(10000)>]
  member __.``isDraw. Normal Case6``() =
    [| Marked O; Marked X; Marked X
       Marked X; Marked O; Marked X
       Marked X; Marked O; Marked X |]
    |> BoardHelper.isDraw |> Assert.IsFalse

  [<TestMethod; Timeout(10000)>]
  member __.``isDraw. Normal Case7``() =
    [| Marked O; Marked X; EmptySlot
       Marked X; Marked O; EmptySlot
       Marked X; Marked O; Marked O |]
    |> BoardHelper.isDraw |> Assert.IsFalse


  // Minimax Tests
  [<TestMethod; Timeout(10000)>]
  member __.``Minimax. Normal Case1``() =
    let strategy = new MinimaxStrategy ()
    let board = [| Marked O; Marked X; Marked O
                   Marked X; Marked O; Marked X
                   Marked X; Marked X; EmptySlot |] |> toBoard
    Assert.AreEqual(9, (strategy :> AI).NextMove O board)

  [<TestMethod; Timeout(10000)>]
  member __.``Minimax. Normal Case2``() =
    let strategy = new MinimaxStrategy ()
    let board = [| Marked O;  Marked X; Marked O
                   Marked X;  Marked O; Marked X
                   EmptySlot; EmptySlot; Marked X |] |> toBoard
    Assert.AreEqual(7, (strategy :> AI).NextMove O board)

  [<TestMethod; Timeout(10000)>]
  member __.``Minimax. Normal Case3``() =
    let strategy = new MinimaxStrategy ()
    let board = [| Marked X; Marked O; Marked X
                   Marked O; Marked X; Marked O
                   Marked O; Marked X; EmptySlot |] |> toBoard
    Assert.AreEqual(9, (strategy :> AI).NextMove X board)

  [<TestMethod; Timeout(10000)>]
  member __.``Minimax. Normal Case4``() =
    let strategy = new MinimaxStrategy ()
    let board = [| Marked O;  Marked X; Marked O
                   Marked X;  Marked X; Marked O
                   EmptySlot; EmptySlot; EmptySlot |] |> toBoard
    Assert.AreEqual(8, (strategy :> AI).NextMove X board)

  [<TestMethod; Timeout(10000)>]
  member __.``Minimax. Normal Case5``() =
    let strategy = new MinimaxStrategy ()
    let board = [| EmptySlot;  Marked O ; EmptySlot
                   EmptySlot;  EmptySlot; Marked X
                   EmptySlot;  EmptySlot; Marked X |] |> toBoard
    Assert.AreEqual(3, (strategy :> AI).NextMove O board)

  [<TestMethod; Timeout(10000)>]
  member __.``Minimax. Normal Case6``() =
    let strategy = new MinimaxStrategy ()
    let board = [| Marked O; EmptySlot; Marked O
                   Marked X; Marked O ; Marked X
                   Marked X; EmptySlot; Marked X |] |> toBoard
    Assert.AreEqual(2, (strategy :> AI).NextMove O board)

  [<TestMethod; Timeout(10000)>]
  member __.``Minimax. Normal Case7``() =
    let strategy = new MinimaxStrategy ()
    let board = [| EmptySlot;  Marked X; Marked O
                   Marked O ;  Marked X; Marked X
                   Marked O ; EmptySlot; Marked O |] |> toBoard
    Assert.AreEqual(8, (strategy :> AI).NextMove X board)
