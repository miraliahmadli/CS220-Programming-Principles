namespace HW11.Tests

open HW11
open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module TestHelper =
  let streaming stream =
    Seq.head stream, Seq.tail stream

  let streamTester stream ans =
    List.fold (fun stream x ->
      let y, stream = streaming stream
      Assert.AreEqual (x, y)
      stream) stream ans |> ignore

[<TestClass>]
type TestClass () =

  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. Position Stream`` () =
    let stream = PositionStream.create 0
    [ 4 ; 3 ; 3 ; 4 ; 2 ; 6 ; 5 ; 2 ; 4 ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. Mole Event Stream`` () =
    let stream = MoleEventStream.create 3u 0
    [ Popup 4 ; NothingHappened ; NothingHappened ; Popup 3 ; NothingHappened ;
      NothingHappened ; Popup 3 ; NothingHappened ; NothingHappened ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. Mallet Event Stream`` () =
    let stream = MalletEventStream.create 0
    [ Hit 4 ; Hit 3 ; Hit 3 ; Hit 4 ; Hit 2 ; Hit 6 ; Hit 5 ; Hit 2 ; Hit 4 ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. Score Evaluation`` () =
    let moles = MoleEventStream.create 3u 0
    let mallets = MalletEventStream.create 0
    Assert.AreEqual (1u, Score.compute moles mallets 9u)

  [<TestMethod; Timeout(10000)>]
  member __.``PositionStream. Normal Behavior`` () =
    let stream = PositionStream.create 220
    [ 3 ; 4 ; 7 ; 5 ; 0 ; 2 ; 1 ; 5 ; 6 ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``MoleEventStream. Normal Behavior`` () =
    let stream = MoleEventStream.create 3u 12345
    [ Popup 5 ; NothingHappened ; NothingHappened ; Popup 2 ; NothingHappened ;
      NothingHappened ; Popup 4 ; NothingHappened ; NothingHappened ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``MoleEventStream. All Popup`` () =
    let stream = MoleEventStream.create 1u 12345
    [ Popup 5 ; Popup 2 ; Popup 4 ; Popup 3 ; Popup 3 ; Popup 0 ; Popup 4 ;
      Popup 7 ; Popup 5 ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``MoleEventStream. Popup Once`` () =
    let stream = MoleEventStream.create 9u 12345
    [ Popup 5 ; NothingHappened ; NothingHappened ; NothingHappened ;
      NothingHappened ; NothingHappened ; NothingHappened ; NothingHappened
      NothingHappened ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``MoleEventStream. Long Sequence`` () =
    let stream = MoleEventStream.create 1u 1
    [ Popup 6 ; Popup 1 ; Popup 8 ; Popup 6 ; Popup 0 ; Popup 0 ; Popup 1 ;
      Popup 0 ; Popup 6 ; Popup 0 ; Popup 5 ; Popup 6 ; Popup 1 ; Popup 4 ;
      Popup 2 ; Popup 6 ; Popup 6 ; Popup 8 ; Popup 1 ; Popup 7 ; Popup 3 ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``MalletEventStream. Normal Behavior`` () =
    let stream = MalletEventStream.create 31337
    [ Hit 5 ; Hit 3 ; Hit 1 ; Hit 4 ; Hit 4 ; Hit 8 ; Hit 6 ; Hit 4 ; Hit 3 ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``MalletEventStream. Long Sequence`` () =
    let stream = MalletEventStream.create 2
    [ Hit 8 ; Hit 8 ; Hit 6 ; Hit 6 ; Hit 7 ; Hit 3 ; Hit 6 ; Hit 7 ; Hit 6 ;
      Hit 0 ; Hit 6 ; Hit 5 ; Hit 8 ; Hit 6 ; Hit 4 ; Hit 2 ; Hit 0 ; Hit 8 ;
      Hit 3 ; Hit 3 ; Hit 3 ]
    |> TestHelper.streamTester stream

  [<TestMethod; Timeout(10000)>]
  member __.``Score. Normal Behavior 1`` () =
    let moles = MoleEventStream.create 3u 12345
    let mallets = MalletEventStream.create 31337
    Assert.AreEqual (2u, Score.compute moles mallets 9u)

  [<TestMethod; Timeout(10000)>]
  member __.``Score. Normal Behavior 2`` () =
    let moles = MoleEventStream.create 1u 12345
    let mallets = MalletEventStream.create 31337
    Assert.AreEqual (3u, Score.compute moles mallets 9u)

  [<TestMethod; Timeout(10000)>]
  member __.``Score. All Hit`` () =
    let moles = MoleEventStream.create 1u 12345
    let mallets = MalletEventStream.create 12345
    Assert.AreEqual (9u, Score.compute moles mallets 9u)

  [<TestMethod; Timeout(10000)>]
  member __.``Score. Long Seuqence`` () =
    let moles = MoleEventStream.create 1u 1
    let mallets = MalletEventStream.create 2
    Assert.AreEqual (10u, Score.compute moles mallets 21u)
