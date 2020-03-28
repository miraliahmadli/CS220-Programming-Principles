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


  (* Prob1 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. Normal Case1`` () =
    let r = MySolution.countLetter "Hello FSharp World" "o"
    Assert.AreEqual(2UL, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. Normal Case2`` () =
    let r = MySolution.countLetter "Hello FSharp World" "A"
    Assert.AreEqual(0UL, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. Normal Case3`` () =
    let r = MySolution.countLetter "1l11l1l1l11l1l1l" "1"
    Assert.AreEqual(9UL, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. Normal Case4`` () =
    let r = MySolution.countLetter "Just give some score" " "
    Assert.AreEqual(3UL, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem1. Normal Case5`` () =
    let r = MySolution.countLetter "131311313313131331333313" "13"
    Assert.AreEqual(9UL, r)


  (* Prob2 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. Normal Case1`` () =
    let matrix1 = SqMatrix.init [ [ 3; 1; 1;]; [1; 3; 1;]; [1; 1; 3;] ]
    let r = MySolution.diagonal matrix1
    let a = [ 3; 3; 3 ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. Normal Case2`` () =
    let matrix1 = SqMatrix.init [ [ 3 ] ]
    let r = MySolution.diagonal matrix1
    let a = [ 3 ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. Normal Case3`` () =
    let matrix1 = SqMatrix.init
                   [[ 3; 1; 1; 1;]; [1; 3; 1; 1;]; [1; 1; 3; 1;]; [1; 1; 1; 3;]]
    let r = MySolution.diagonal matrix1
    let a = [ 3; 3; 3; 3 ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. Normal Case4`` () =
    let matrix1 = SqMatrix.init [ [ 3; 1;]; [1; 2;] ]
    let r = MySolution.diagonal matrix1
    let a = [ 3; 2; ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem2. Normal Case5`` () =
    let matrix1 = SqMatrix.init
                    [ [ 1; 1; 1; 1; 1 ]; [ 2; 2; 2; 2; 2 ]; [ 3; 3; 3; 3; 3 ];
                      [ 4; 4; 4; 4; 4 ]; [ 5; 5; 5; 5; 5 ] ]
    let r = MySolution.diagonal matrix1
    let a = [ 1; 2; 3; 4; 5 ]
    Assert.AreEqual(a, r)


  (* Prob3 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. Normal Case1`` () =
    let matrix1 = SqMatrix.init [ [ 3; 1; 1;]; [1; 3; 1;]; [1; 1; 3;] ]
    let r = MySolution.transpose matrix1
    let a = SqMatrix.init  [ [ 3; 1; 1;]; [1; 3; 1;]; [1; 1; 3;] ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. Normal Case2`` () =
    let matrix1 = SqMatrix.init [ [ 3 ] ]
    let r = MySolution.transpose matrix1
    let a = [[ 3 ]]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. Normal Case3`` () =
    let matrix1 = SqMatrix.init
                   [[ 3; 1; 1; 1;]; [1; 3; 1; 1;]; [1; 1; 3; 1;]; [1; 1; 1; 3;]]
    let r = MySolution.transpose matrix1
    let a = SqMatrix.init
              [[ 3; 1; 1; 1;]; [1; 3; 1; 1;]; [1; 1; 3; 1;]; [1; 1; 1; 3;]]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. Normal Case4`` () =
    let matrix1 = SqMatrix.init [ [ 3; 2;]; [1; 2;] ]
    let r = MySolution.transpose matrix1
    let a =SqMatrix.init [ [ 3; 1; ]; [2; 2;] ]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem3. Normal Case5`` () =
    let matrix1 = SqMatrix.init [ [ 1; 2;]; [3; 4;] ]
    let r = MySolution.transpose matrix1
    let a =SqMatrix.init [ [ 1; 3; ]; [2; 4;] ]
    Assert.AreEqual(a, r)


  (* Prob4 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. Normal Case1`` () =
    let r = MySolution.rotate [ 1 ; 2 ; 3 ; 4 ] 4
    Assert.AreEqual([ 1; 2; 3; 4 ], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. Normal Case2`` () =
    let r = MySolution.rotate [ 1 ; 2 ; 3 ; 4 ] -2
    Assert.AreEqual([ 3; 4; 1; 2 ], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. Normal Case3`` () =
    let r = MySolution.rotate [ 'a'; 'b'; 'c'; 'd' ] 2
    Assert.AreEqual([ 'c'; 'd'; 'a'; 'b';], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. Normal Case4`` () =
    let r = MySolution.rotate [ 1; 2] 9
    Assert.AreEqual([ 2; 1], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. Normal Case5`` () =
    let r = MySolution.rotate [ 'c'; 'd'; 'e'; 'a' ; 'b'] -4
    Assert.AreEqual([ 'b'; 'c'; 'd'; 'e'; 'a'], r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem4. Normal Case6`` () =
    let r = MySolution.rotate [ 1; 2; 3; 4; ] 0
    Assert.AreEqual([ 1; 2; 3; 4;], r)


  (* Prob5 Hidden Tests *)
  [<TestMethod; Timeout(10000)>]
  member __.``Problem5. Normal Case1`` () =
    let r = MySolution.hanoi 3 1 4
    let a = [(3, 2); (3, 1); (2, 1); (3, 2); (1, 3); (1, 2); (3, 2); (3, 1);
             (2, 1); (2, 3); (1, 3); (2, 1); (3, 2); (3, 1); (2, 1)]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem5. Normal Case2`` () =
    let r = MySolution.hanoi 2 3 5
    let a = [(2, 3); (2, 1); (3, 1); (2, 3); (1, 2); (1, 3); (2, 3); (2, 1);
             (3, 1); (3, 2); (1, 2); (3, 1); (2, 3); (2, 1); (3, 1); (2, 3);
             (1, 2); (1, 3); (2, 3); (1, 2); (3, 1); (3, 2); (1, 2); (1, 3);
             (2, 3); (2, 1); (3, 1); (2, 3); (1, 2); (1, 3); (2, 3)]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem5. Normal Case3`` () =
    let r = MySolution.hanoi 1 3 2
    let a = [(1, 2); (1, 3); (2, 3)]
    Assert.AreEqual(a, r)

  [<TestMethod; Timeout(10000)>]
  member __.``Problem5. Normal Case4`` () =
    let r = MySolution.hanoi 2 1 3
    let a = [(2, 1); (2, 3); (1, 3); (2, 1); (3, 2); (3, 1); (2, 1)]
    Assert.AreEqual(a, r)

