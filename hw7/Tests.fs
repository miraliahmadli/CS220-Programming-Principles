namespace HW7.Tests

open HW7

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  let matrix = SqMatrix.init [ [ 1 ; 2 ; 3 ] ; [ 4 ; 5 ; 6 ] ; [ 7 ; 8 ; 9 ] ]

  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. A`` () =
    let r = MySolution.countLetter "my name is Ann" "n"
    Assert.AreEqual(3UL, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. A`` () =
    let r = MySolution.diagonal matrix
    let a = [ 1 ; 5 ; 9 ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. A`` () =
    let r = MySolution.transpose matrix
    let a = SqMatrix.init [ [ 1 ; 4 ; 7 ] ; [ 2 ; 5 ; 8 ] ; [ 3 ; 6 ; 9 ] ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. A`` () =
    let r = MySolution.rotate [ 1 ; 2 ; 3 ; 4 ] 2
    Assert.AreEqual([ 3 ; 4 ; 1 ; 2 ], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem5. A`` () =
    let r = MySolution.hanoi 1 2 2
    let a = [ (1, 3) ; (1, 2) ; (3, 2) ]
    Assert.AreEqual(a, r)
