namespace HW2.Tests

open HW2
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  let rangeCheck submit answer =
    let threshold = 0.000001
    let high = submit + threshold
    let low = submit - threshold
    if answer < high && answer > low then true
    else false

  [<TestMethod; Timeout(10000)>]
  member __.``Probem 1.A``() =
    let r = MySolution.prob1 1 2 2
    Assert.AreEqual(8, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Probem 1.B``() =
    let r = MySolution.prob1 10 1 20
    Assert.AreEqual(500, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Probem 4.A``() =
    let r = MySolution.prob4 10
    Assert.AreEqual(31, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Probem 4.B``() =
    let r = MySolution.prob4 2
    Assert.AreEqual(28, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Probem 5.A``() =
    let r = MySolution.prob5 2019 2
    Assert.AreEqual(28, r)


  (* Prob1 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case1``() =
    let r = MySolution.prob1 3 4 5
    Assert.AreEqual(41, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case2``() =
    let r = MySolution.prob1 120 -402 402
    Assert.AreEqual(176004, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case3``() =
    let r = MySolution.prob1 -2 -3 0
    Assert.AreEqual(4, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Every number is Equal``() =
    let r = MySolution.prob1 -1 -1 -1
    Assert.AreEqual(2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. OverFlow on First Large Number``() =
    let r = MySolution.prob1 0x12345 1 2
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. OverFlow on Second Large Number``() =
    let r = MySolution.prob1 -0x12345 -0x123456 0x42
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. OverFlow on Addition``() =
    let r = MySolution.prob1 0xa000 0xd000 0x8000
    Assert.AreEqual(-1, r)


  (* Prob2 Hidden Test *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case1``() =
    let r = MySolution.prob2 ""
    Assert.AreEqual("\n", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case2``() =
    let r = MySolution.prob2 "Case2\n"
    Assert.AreEqual("Case2\n", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case3``() =
    let r = MySolution.prob2 "Case3\n\n"
    Assert.AreEqual("Case3\n\n", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case4``() =
    let r = MySolution.prob2 "\nCase4"
    Assert.AreEqual("\nCase4\n", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case5``() =
    let r = MySolution.prob2 "This is test case 5!:)"
    Assert.AreEqual("This is test case 5!:)\n", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case6``() =
    let r = MySolution.prob2 "\\"
    Assert.AreEqual("\\\n", r)


  (* Prob3 Hidden Test *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case1``() =
    let r = MySolution.prob3 1.1 1.1 1.1
    Assert.AreEqual(nan, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case2``() =
    let r = rangeCheck (MySolution.prob3 1.0 2.0 1.0) -1.0
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case3``() =
    let r = MySolution.prob3 0.0 0.0 0.0
    Assert.AreEqual(nan, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case4``() =
    let r = rangeCheck (MySolution.prob3 0.0 1.0 2.0) -2.0
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case5``() =
    let r = MySolution.prob3 1.0 0.0 1.0
    Assert.AreEqual(nan, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case6``() =
    let r = rangeCheck (MySolution.prob3 1.0 0.0 -4.0) 2.0
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case7``() =
    let r = MySolution.prob3 -12.0 8.0 2.0
    let d = 8.0*8.0 - (4.0 * -12.0 * 2.0)
    let a = (-8.0 - sqrt d) / (2.0 * -12.0)
    let checker = rangeCheck r a
    Assert.IsTrue(checker)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case8``() =
    let r = MySolution.prob3 0.0 0.0 2.0
    Assert.AreEqual(nan, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Edge Case1``() =
    let r = MySolution.prob3 nan nan nan
    Assert.AreEqual(nan, r)


  (* Prob4 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case1``() =
    let r = MySolution.prob4 1
    Assert.AreEqual(31, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case2``() =
    let r = MySolution.prob4 2
    Assert.AreEqual(28, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case3``() =
    let r = MySolution.prob4 7
    Assert.AreEqual(31, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case4``() =
    let r = MySolution.prob4 8
    Assert.AreEqual(31, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case5``() =
    let r = MySolution.prob4 9
    Assert.AreEqual(30, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Edge Case1``() =
    let r = MySolution.prob4 13
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Edge Case2``() =
    let r = MySolution.prob4 -1
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Edge Case3``() =
    let r = MySolution.prob4 0
    Assert.AreEqual(-1, r)


  (* Prob5 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case1``() =
    let r = MySolution.prob5 1601 2
    Assert.AreEqual(28, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case2``() =
    let r = MySolution.prob5 1732 2
    Assert.AreEqual(29, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case3``() =
    let r = MySolution.prob5 2014 4
    Assert.AreEqual(30, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case4``() =
    let r = MySolution.prob5 2019 3
    Assert.AreEqual(31, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case5``() =
    let r = MySolution.prob5 1600 2
    Assert.AreEqual(29, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Edge Case1``() =
    let r = MySolution.prob5 -1 3
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Edge Case2``() =
    let r = MySolution.prob5 1600 -1
    Assert.AreEqual(-1, r)

