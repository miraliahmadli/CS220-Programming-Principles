namespace HW4.Tests

open HW4

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  [<TestMethod>]
  member __.``Problem1.A`` () =
    Assert.AreEqual(4, MySolution.prob1 1 40)

  [<TestMethod>]
  member __.``pow Test`` () =
    Assert.AreEqual("abcabc", MySolution.pow "abc" 2)

  [<TestMethod>]
  member __.``pow rev Test`` () =
    Assert.AreEqual("cbacba", MySolution.pow "abc" -2)

  [<TestMethod>]
  member __.``smallestDivisor Test A`` () =
    Assert.AreEqual(0u, MySolution.smallestDivisor 0u)

  [<TestMethod>]
  member __.``smallestDivisor Test B`` () =
    Assert.AreEqual(2u, MySolution.smallestDivisor 120u)

  [<TestMethod; Timeout(10000)>]
  member __.``isPrime Test A`` () =
    Assert.IsTrue(MySolution.isPrime 3u)

  [<TestMethod; Timeout(10000)>]
  member __.``isPrime Test B`` () =
    Assert.IsFalse(MySolution.isPrime 111u)

  [<TestMethod>]
  member __.``isFeasible A`` () =
    Assert.IsTrue (MySolution.isFeasible 1u 3u 0u)

  [<TestMethod>]
  member __.``isFeasible B`` () =
    Assert.IsFalse (MySolution.isFeasible 1u 3u 4u)


  (* Prob1 Hidden Test *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case1``() =
    let r = MySolution.prob1 30 40
    Assert.AreEqual(0, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case2``() =
    let r = MySolution.prob1 40 50
    Assert.AreEqual(2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case3``() =
    let r = MySolution.prob1 0 0
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case4``() =
    let r = MySolution.prob1 -300 400
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case5``() =
    let r = MySolution.prob1 1 -1
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case6``() =
    let r = MySolution.prob1 -300 -200
    Assert.AreEqual(-1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case7``() =
    let r = MySolution.prob1 7 100
    Assert.AreEqual(12, r)


  (* Prob2 Hidden Test *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case1``() =
    let r = MySolution.pow "cs220" 0
    Assert.AreEqual("", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case2``() =
    let r = MySolution.pow "cs220" -1
    Assert.AreEqual("022sc", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case3``() =
    let r = MySolution.pow "cs220" 1
    Assert.AreEqual("cs220", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case4``() =
    let r = MySolution.pow "cs220" 5
    Assert.AreEqual("cs220cs220cs220cs220cs220", r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case5``() =
    let r = MySolution.pow "abcde" -5
    Assert.AreEqual("edcbaedcbaedcbaedcbaedcba", r)


  (* Prob3 Hidden Test *)
  [<TestMethod>]
  member __.``Problem 3. Normal Case1`` () =
    Assert.AreEqual(0u, MySolution.smallestDivisor 0u)

  [<TestMethod>]
  member __.``Problem 3. Normal Case2`` () =
    Assert.AreEqual(2u, MySolution.smallestDivisor 120u)

  [<TestMethod>]
  member __.``Problem 3. Normal Case3`` () =
    Assert.AreEqual(65537u, MySolution.smallestDivisor 65537u)

  [<TestMethod>]
  member __.``Problem 3. Normal Case4`` () =
    Assert.AreEqual(401u, MySolution.smallestDivisor 1688611u)


  (* Prob4 Hidden Test *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case1``() =
    let r = MySolution.isPrime 402103u
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case2``() =
    let r = MySolution.isPrime 65537u
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case3``() =
    let r = MySolution.isPrime 2u
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case4``() =
    let r = MySolution.isPrime 3u
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case5``() =
    let r = MySolution.isPrime 1u
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case6``() =
    let r = MySolution.isPrime 0u
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case7``() =
    let r = MySolution.isPrime 1688611u
    Assert.IsFalse(r)


  (* Prob5 Hidden Test *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case1``() =
    let r = MySolution.isFeasible 2u 3u 4u
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case2``() =
    let r = MySolution.isFeasible 5u 10u 20u
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case3``() =
    let r = MySolution.isFeasible 1u 1u 1u
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case4``() =
    let r = MySolution.isFeasible 0u 1u 0u
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Edge Case1``() =
    let r = MySolution.isFeasible 2u 1u 0u
    Assert.IsFalse(r)

