namespace HW6.Tests

open HW6
open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. removeOdd 1`` () =
    Assert.AreEqual([ 2 ], MySolution.removeOdd [ 1; 2; 3 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. getSmallest`` () =
    Assert.AreEqual(Some 1, MySolution.getSmallest [ 1; 2; 3 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. take`` () =
    Assert.AreEqual([ "a" ], MySolution.take [ "a"; "b"; "c" ] 1u)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. runLength`` () =
    let r = MySolution.runLength [ 1; 2; 2; 2; 3; 3 ]
    Assert.AreEqual([ (1 ,1); (2, 3); (3, 2) ], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. isPalindrome`` () =
    Assert.IsTrue(MySolution.isPalindrome [ 1; 2; 1 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 6. slice`` () =
    Assert.AreEqual([ 2; 3; 4 ], MySolution.slice [ 1; 2; 3; 4; 5 ] 2 4)


  (* Prob1 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case1`` () =
    Assert.AreEqual([ 2; 4 ], MySolution.removeOdd [ 1; 2; 3; 4])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case2`` () =
    Assert.IsTrue(MySolution.removeOdd [ 1; 3 ] |> List.isEmpty)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case3`` () =
    Assert.AreEqual([ 0 ], MySolution.removeOdd [ 0 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case4`` () =
    Assert.AreEqual([ -2 ], MySolution.removeOdd [ -1; -2 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 1. Normal Case5`` () =
    Assert.AreEqual([ -2; 0; 2; ],
      MySolution.removeOdd [ -3; -2; -1; 0; 1; 2; 3; ])


  (* Prob2 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case1`` () =
    Assert.AreEqual(Some -1, MySolution.getSmallest [ -1; 0; 1 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case2`` () =
    Assert.AreEqual(Some -1, MySolution.getSmallest [ 1; 0; -1 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case3`` () =
    Assert.AreEqual(Some 0, MySolution.getSmallest [ 0 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case4`` () =
    Assert.AreEqual(None, MySolution.getSmallest [])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case5`` () =
    Assert.AreEqual(Some 320, MySolution.getSmallest [ 500; 400; 320 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 2. Normal Case6`` () =
    Assert.AreEqual(Some -400, MySolution.getSmallest [ -200; -300; -400 ])


  (* Prob3 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case1`` () =
    Assert.AreEqual([ 1 ], MySolution.take [ 1; 2; 3 ] 1u)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case2`` () =
    Assert.AreEqual([ "a"; "b" ], MySolution.take [ "a"; "b"; "c"; ] 2u)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case3`` () =
    Assert.AreEqual([ 1; 2; 3 ], MySolution.take [ 1; 2; 3 ] 4u)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case4`` () =
    Assert.IsTrue(MySolution.take ["a", "b", "c"] 0u |> List.isEmpty)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 3. Normal Case5`` () =
    Assert.IsTrue(MySolution.take [ 1; 2; 3; 5 ] 0u |> List.isEmpty)


  (* Prob4 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case1`` () =
    let r = MySolution.runLength [ "1"; "2"; "2"; "2"; "3"; "3" ]
    Assert.AreEqual([ ("1", 1); ("2", 3); ("3", 2) ], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case2`` () =
    Assert.IsTrue(MySolution.runLength [] |> List.isEmpty)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case3`` () =
    let r = MySolution.runLength [ 111; 112; 113; 114; ]
    Assert.AreEqual([ (111, 1); (112, 1); (113, 1); (114, 1)], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case4`` () =
    let r = MySolution.runLength [ "1"; "1"; "1"; "1"]
    Assert.AreEqual([ ("1", 4) ], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 4. Normal Case5`` () =
    let r = MySolution.runLength [ 1; 1; 2; 3; 3; 4; 4; 4; 3; 2 ]
    Assert.AreEqual([ (1, 2); (2, 1); (3, 2); (4, 3); (3, 1); (2, 1) ], r)


  (* Prob5 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case1`` () =
    Assert.IsTrue(MySolution.isPalindrome
      [ "N";"O";"L";"E";"M";"O";"N";",";"N";"O";"M";"E";"L";"O";"N" ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case2`` () =
    Assert.IsFalse(MySolution.isPalindrome [ 1; 2; 3; 4 ])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case3`` () =
    Assert.IsFalse(MySolution.isPalindrome ["1"; "2"; "3"])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case4`` () =
    Assert.IsTrue(MySolution.isPalindrome ["1"; "2"; "1"])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case5`` () =
    Assert.IsTrue(MySolution.isPalindrome ["abcd";"abcd";"abcd";"abcd";"abcd"])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Normal Case6`` () =
    Assert.IsTrue(MySolution.isPalindrome ["abcd";"abcd";"abcd";"abcd"])

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 5. Edge Case1`` () =
    Assert.IsTrue(MySolution.isPalindrome [])



  (* Prob6 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem 6. Normal Case1`` () =
    Assert.AreEqual([ 1; 2; 3; 4; 5 ], MySolution.slice [ 1; 2; 3; 4; 5 ] 1 5)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 6. Normal Case2`` () =
    Assert.AreEqual([ 3; 4], MySolution.slice [ 1; 2; 3; 4; 5 ] 3 4)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 6. Normal Case3`` () =
    Assert.AreEqual([ 2; 3; 4; 5; ], MySolution.slice [ 1; 2; 3; 4; 5; 6 ] 2 5)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 6. Normal Case4`` () =
    let r = MySolution.slice [ "1"; "2"; "3"; "4"; "5" ] 2 4
    Assert.AreEqual(["2"; "3"; "4"], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 6. Normal Case5`` () =
    let r = MySolution.slice [ "1"; "2"; "3"; "4"; "5" ] 4 4
    Assert.AreEqual(["4"], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem 6. Edge Case1`` () =
    Assert.IsTrue(MySolution.slice [ 1; 2; 3; 4; 5; ] 6 8 |> List.isEmpty)

