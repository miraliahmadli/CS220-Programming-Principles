namespace HW3.Tests

open HW3
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  let rangeCheck submit answer =
    let threshold = 0.000001
    let high = submit + threshold
    let low = submit - threshold
    if answer < high && answer > low then true
    else false

  [<TestMethod>]
  member __.``Problem 1.A``() =
    let r = MySolution.prob1 1
    Assert.AreEqual(1.0, r)

  [<TestMethod>]
  member __.``Problem 2.A``() =
    let r = MySolution.prob2 100
    Assert.AreEqual(19, r)

  [<TestMethod>]
  member __.``Problem 2.B``() =
    let r = MySolution.prob2 1000
    Assert.AreEqual(4908, r)

  [<TestMethod>]
  member __.``Problem 3.A``() =
    let r = MySolution.prob3 54 24
    Assert.AreEqual(6, r)

  [<TestMethod>]
  member __.``Problem 4.A``() =
    let r = MySolution.prob4 1
    Assert.AreEqual(1, r)

  [<TestMethod>]
  member __.``Problem 5.A``() =
    let r = MySolution.prob5 1 2
    Assert.AreEqual(6, r)


  (* Prob1 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case1``() =
    let r = rangeCheck (MySolution.prob1 4) (1.0 + 1.0/2.0 + 1.0/3.0 + 1.0/4.0)
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case2``() =
    let r = rangeCheck (MySolution.prob1 402) 6.57491101895159
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case3``() =
    let r = MySolution.prob1 10423
    let solve n =
      let rec aux ans n =
        if n =1 then ans else aux (ans + 1.0 / float n) (n - 1)
      if n < 1 then nan else aux 1.0 n
    let a = solve 10423
    Assert.IsTrue(rangeCheck r a)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Edge Case1``() =
    let r = MySolution.prob1 -1
    Assert.AreEqual(nan, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Edge Case2``() =
    let r = MySolution.prob1 0
    Assert.AreEqual(nan, r)


  (* Prob2 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case1``() =
    let r = MySolution.prob2 30
    Assert.AreEqual(4, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case2``() =
    let r = MySolution.prob2 328
    Assert.AreEqual(218, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case3``() =
    let r = MySolution.prob2 124
    Assert.AreEqual(27, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case4``() =
    let r = MySolution.prob2 1337
    Assert.AreEqual(12207, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Edge Case1``() =
    let r = MySolution.prob2 -4021
    Assert.AreEqual(-1, r)


  (* Prob3 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case1``() =
    let r = MySolution.prob3 59129123 1929149
    Assert.AreEqual(1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case2``() =
    let r = MySolution.prob3 10502050 4012032
    Assert.AreEqual(2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case3``() =
    let r = MySolution.prob3 10 10
    Assert.AreEqual(10, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case4``() =
    let r = MySolution.prob3 1118016 737280
    Assert.AreEqual(576, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case5``() =
    let r = MySolution.prob3 -1 -1
    Assert.AreEqual(1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Edge Case1``() =
    let r = MySolution.prob3 10 0
    Assert.AreEqual(10, r)


  (* Prob4 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case1``() =
    let r = MySolution.prob4 4
    Assert.AreEqual(10, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case2``() =
    let r = MySolution.prob4 16
    Assert.AreEqual(136, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case3``() =
    let r = MySolution.prob4 10204
    Assert.AreEqual(52065910, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Edge Case1``() =
    let r = MySolution.prob4 0
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Edge Case2``() =
    let r = MySolution.prob4 -1
    Assert.AreEqual(-1, r)


  (* Prob5 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case1``() =
    let r = MySolution.prob5 2 4
    Assert.AreEqual(20, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case2``() =
    let r = MySolution.prob5 -1 10
    Assert.AreEqual(44, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case3``() =
    let r = MySolution.prob5 10 -1
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case4``() =
    let r = MySolution.prob5 -10 -10
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case5``() =
    let r = MySolution.prob5 0 0
    Assert.AreEqual(0, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case6``() =
    let r = MySolution.prob5 102 4
    Assert.AreEqual(520, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case7``() =
    let r = MySolution.prob5 0 200
    Assert.AreEqual(20100, r)

