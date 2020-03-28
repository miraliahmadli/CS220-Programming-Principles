namespace HW5.Tests

open HW5

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  let rangeCheck submit answer =
    let threshold = 0.000001
    let high = submit + threshold
    let low = submit - threshold
    if answer < high && answer > low then true
    else false

  let pair (x: int) (y: int) m : int = m x y

  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. A`` () =
    let a = Square 4.5
    let r = rangeCheck (MySolution.area a) 20.25
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. A`` () =
    let p = pair 1 2
    let r = MySolution.fst p
    Assert.AreEqual(1, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. A`` () =
    let t1 = { Hours = 1; Minutes = 40; AMPM = AM }
    let t2 = { Hours = 4; Minutes = 10; AMPM = PM }
    let r = MySolution.isEarly t1 t2
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. A`` () =
    let t = { Hours = 1; Minutes = 40; AMPM = AM }
    let r = MySolution.addMinutes t 5
    let a = { Hours = 1; Minutes = 45; AMPM = AM }
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem5. A`` () =
    let a = StraightLine (4, 4)
    let r = MySolution.mirrorX a
    let b = StraightLine (-4, -4)
    Assert.AreEqual(b, r)


  (* Prob1 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case1``() =
    let a = Circle 1.0
    let r = rangeCheck (MySolution.area a) 3.14159265358979
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case2``() =
    let a = Triangle (2.0, 2.0, 2.0)
    let r = rangeCheck (MySolution.area a) 1.73205080756888
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case3``() =
    let a = Square 4.0
    let r = rangeCheck (MySolution.area a) 16.0
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case4``() =
    let a = Triangle (10.0, 12.0, 4.0)
    let r = rangeCheck (MySolution.area a) 18.7349939951952
    Assert.IsTrue(r)


  (* Prob2 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case1``() =
    let p = pair 3 4
    let r = MySolution.fst p
    Assert.AreEqual(3, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case2``() =
    let p = pair 12030 12040
    let r = MySolution.fst p
    Assert.AreEqual(12030, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case3``() =
    let p = pair -20 -30
    let r = MySolution.fst p
    Assert.AreEqual(-20, r)


  (* Prob3 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case1``() =
    let t1 = { Hours = 0; Minutes = 0; AMPM = AM}
    let t2 = { Hours = 0; Minutes = 0; AMPM = PM}
    let r = MySolution.isEarly t1 t2
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case2``() =
    let t1 = { Hours = 2; Minutes = 2; AMPM = PM}
    let t2 = { Hours = 2; Minutes = 2; AMPM = AM}
    let r = MySolution.isEarly t1 t2
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case3``() =
    let t1 = { Hours = 2; Minutes = 2; AMPM = AM}
    let t2 = { Hours = 2; Minutes = 2; AMPM = AM}
    let r = MySolution.isEarly t1 t2
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case4``() =
    let t1 = { Hours = 2; Minutes = 20; AMPM = PM}
    let t2 = { Hours = 2; Minutes = 21; AMPM = PM}
    let r = MySolution.isEarly t1 t2
    Assert.IsTrue(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case5``() =
    let t1 = { Hours = 2; Minutes = 21; AMPM = AM}
    let t2 = { Hours = 2; Minutes = 20; AMPM = AM}
    let r = MySolution.isEarly t1 t2
    Assert.IsFalse(r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case6``() =
    let t1 = { Hours = 3; Minutes = 20; AMPM = PM}
    let t2 = { Hours = 2; Minutes = 20; AMPM = PM}
    let r = MySolution.isEarly t1 t2
    Assert.IsFalse(r)


  (* Prob4 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case1``() =
    let t1 = { Hours = 3; Minutes = 40; AMPM = AM}
    let r = MySolution.addMinutes t1 20
    let t2 = { Hours = 4; Minutes = 0; AMPM = AM}
    Assert.AreEqual(t2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case2``() =
    let t1 = { Hours = 3; Minutes = 40; AMPM = PM}
    let r = MySolution.addMinutes t1 19
    let t2 = { Hours = 3; Minutes = 59; AMPM = PM}
    Assert.AreEqual(t2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case3``() =
    let t1 = { Hours = 11; Minutes = 10; AMPM = AM}
    let r = MySolution.addMinutes t1 50
    let t2 = { Hours = 0; Minutes = 0; AMPM = PM}
    Assert.AreEqual(t2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case4``() =
    let t1 = { Hours = 11; Minutes = 30; AMPM = PM}
    let r = MySolution.addMinutes t1 40
    let t2 = { Hours = 0; Minutes = 10; AMPM = AM}
    Assert.AreEqual(t2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case5``() =
    let t1 = { Hours = 0; Minutes = 0; AMPM = AM}
    let r = MySolution.addMinutes t1 -20
    let t2 = { Hours = 11; Minutes = 40; AMPM = PM}
    Assert.AreEqual(t2, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case6``() =
    let t1 = { Hours = 0; Minutes = 50; AMPM = PM}
    let r = MySolution.addMinutes t1 -100
    let t2 = { Hours = 11; Minutes = 10; AMPM = AM}
    Assert.AreEqual(t2, r)


  (* Prob5 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case1``() =
    let a = StraightLine (10, 10)
    let r = MySolution.mirrorX a
    let b = StraightLine (-10, -10)
    Assert.AreEqual(b, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case2``() =
    let a = StraightLine (20, 20)
    let r = MySolution.mirrorY a
    let b = StraightLine (-20, 20)
    Assert.AreEqual(b, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case3``() =
    let a = StraightLine (-1, -1)
    let r = MySolution.mirrorX a
    let b = StraightLine (1, 1)
    Assert.AreEqual(b, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case4``() =
    let a = StraightLine (-1, 1)
    let r = MySolution.mirrorY a
    let b = StraightLine (1, 1)
    Assert.AreEqual(b, r)

