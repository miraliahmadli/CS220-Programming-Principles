namespace HW8.Tests

open HW8
open HW8.RationalNumber
open HW8.RationalNumberOperation
open HW8.MyLibrary
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  let equal (n1: RationalNumber) (n2: RationalNumber): bool =
    match n1, n2 with
    | { Numerator = 0ul}, { Numerator = 0ul } -> true
    | { Sign = s1; Numerator = num1; Denominator = denom1 },
      { Sign = s2; Numerator = num2; Denominator = denom2 } when s1 = s2 ->
      (uint64 num1) * (uint64 denom2) = (uint64 num2) * (uint64 denom1)
    | _ -> false

  [<TestMethod; Timeout(10000)>]
  member __.``arctan``() =
    let t = arctan one |> Option.get
    // Radian to degree.
    let result = div (mul t (make Positive 180ul 1ul)) pi |> toInt
    Assert.AreEqual (45, result)

  // eq function test
  [<TestMethod; Timeout(10000)>]
  member __.``eq function. Normal Case1``() =
    let a = make Positive 10ul 13ul
    let b = make Positive 10ul 13ul
    let result = eq a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``eq function. Normal Case2``() =
    let a = make Negative 10ul 13ul
    let b = make Negative 10ul 13ul
    let result = eq a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``eq function. Normal Case3``() =
    let a = make Positive 8ul 13ul
    let b = make Positive 10ul 13ul
    let result = eq a b
    Assert.IsFalse (result)

  [<TestMethod; Timeout(10000)>]
  member __.``eq function. Normal Case4``() =
    let a = make Negative 10ul 13ul
    let b = make Positive 10ul 13ul
    let result = eq a b
    Assert.IsFalse (result)

  [<TestMethod; Timeout(10000)>]
  member __.``eq function. Edge Case1``() =
    let a = make Negative 0ul 1ul
    let b = make Positive 0ul 1ul
    let result = eq a b
    Assert.IsTrue (result)


  // add function test
  [<TestMethod; Timeout(10000)>]
  member __.``add funtion. Normal Case1``() =
    let a = make Positive 10ul 17ul
    let b = make Positive 2ul  17ul
    let calc = add a b
    let p = make Positive 12ul 17ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``add funtion. Normal Case2``() =
    let a = make Positive 10ul 17ul
    let b = make Negative 7ul  17ul
    let calc = add a b
    let p = make Positive 3ul 17ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``add funtion. Normal Case3``() =
    let a = make Negative 3ul 17ul
    let b = make Negative 7ul 17ul
    let calc = add a b
    let p = make Negative 10ul 17ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``add funtion. Normal Case4``() =
    let a = make Negative 3ul 17ul
    let b = make Negative 7ul 17ul
    let calc = add a b
    let p = make Negative 10ul 17ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``add funtion. Normal Case5``() =
    let a = make Negative 2ul 3ul
    let b = make Negative 1ul 5ul
    let calc = add a b
    let p = make Negative 13ul 15ul
    let result = equal p calc
    Assert.IsTrue (result)

  // sub function test
  [<TestMethod; Timeout(10000)>]
  member __.``sub function. Normal Case1``() =
    let a = make Positive 2ul 137ul
    let b = make Positive 1ul 137ul
    let calc = sub a b
    let p = make Positive 1ul 137ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``sub function. Normal Case2``() =
    let a = make Negative 2ul 137ul
    let b = make Positive 1ul 137ul
    let calc = sub a b
    let p = make Negative 3ul 137ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``sub function. Normal Case3``() =
    let a = make Negative 1ul 137ul
    let b = make Negative 2ul 137ul
    let calc = sub a b
    let p = make Positive 1ul 137ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``sub function. Normal Case4``() =
    let a = make Positive 2ul 43ul
    let b = make Positive 1ul 52ul
    let calc = sub a b
    let p = make Positive 61ul 2236ul
    let result = equal p calc
    Assert.IsTrue (result)

  // mul function test
  [<TestMethod; Timeout(10000)>]
  member __.``mul function. Normal Case1``() =
    let a = make Positive 2ul 3ul
    let b = make Positive 1ul 3ul
    let calc = mul a b
    let p = make Positive 2ul 9ul
    let result = eq p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``mul function. Normal Case2``() =
    let a = make Positive 2ul 5ul
    let b = make Negative 6ul 7ul
    let calc = mul a b
    let p = make Negative 12ul 35ul
    let result = eq p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``mul function. Normal Case3``() =
    let a = make Negative 3ul 4ul
    let b = make Negative 9ul 16ul
    let calc = mul a b
    let p = make Positive 27ul 64ul
    let result = eq p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``mul function. Normal Case4``() =
    let a = make Positive 23ul 32ul
    let b = make Positive 32ul 23ul
    let calc = mul a b
    let p = make Positive 1ul 1ul
    let result = eq p calc
    Assert.IsTrue (result)

  // div function test
  [<TestMethod; Timeout(10000)>]
  member __.``div function. Normal Case1``() =
    let a = make Positive 2ul 3ul
    let b = make Positive 4ul 3ul
    let calc = div a b
    let p = make Positive 1ul 2ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``div function. Normal Case2``() =
    let a = make Positive 1ul 13ul
    let b = make Negative 5ul 9ul
    let calc = div a b
    let p = make Negative 9ul 65ul
    let result = equal p calc
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``div function. Normal Case3``() =
    let a = make Negative 1ul 3ul
    let b = make Negative 1ul 3ul
    let calc = div a b
    let p = make Positive 3ul 3ul
    let result = equal p calc
    Assert.IsTrue (result)

  // new function test
  [<TestMethod; Timeout(10000)>]
  member __.``neq function. Normal Case1``() =
    let a = make Positive 2ul 3ul
    let b = make Positive 1ul 3ul
    let result = neq a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``neq function. Normal Case2``() =
    let a = make Positive 2ul 3ul
    let b = make Positive 2ul 3ul
    let result = neq a b
    Assert.IsFalse (result)

  [<TestMethod; Timeout(10000)>]
  member __.``neq function. Normal Case3``() =
    let a = make Positive 2ul 3ul
    let b = make Negative 2ul 3ul
    let result = neq a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``neq function. Normal Case4``() =
    let a = make Negative 2ul 3ul
    let b = make Negative 2ul 3ul
    let result = neq a b
    Assert.IsFalse (result)

  [<TestMethod; Timeout(10000)>]
  member __.``neq function. Normal Case5``() =
    let a = make Negative 2ul 3ul
    let b = make Negative 6ul 9ul
    let result = neq a b
    Assert.IsFalse (result)

  // gt function test
  [<TestMethod; Timeout(10000)>]
  member __.``gt function. Normal Case1``() =
    let a = make Positive 2ul 3ul
    let b = make Positive 1ul 3ul
    let result = gt a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``gt function. Normal Case2``() =
    let a = make Positive 2ul 8ul
    let b = make Positive 5ul 7ul
    let result = gt a b
    Assert.IsFalse (result)

  [<TestMethod; Timeout(10000)>]
  member __.``gt function. Normal Case3``() =
    let a = make Positive 2ul 5ul
    let b = make Positive 3ul 9ul
    let result = gt a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``gt function. Normal Case4``() =
    let a = make Positive 2ul 7ul
    let b = make Negative 2ul 7ul
    let result = gt a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``gt function. Normal Case5``() =
    let a = make Negative 2ul 7ul
    let b = make Positive 2ul 7ul
    let result = gt a b
    Assert.IsFalse (result)

  [<TestMethod; Timeout(10000)>]
  member __.``gt function. Normal Case6``() =
    let a = make Negative 8ul 7ul
    let b = make Negative 2ul 7ul
    let result = gt a b
    Assert.IsFalse (result)

  // ge function test
  [<TestMethod; Timeout(10000)>]
  member __.``ge function. Normal Case1``() =
    let a = make Positive 2ul 3ul
    let b = make Positive 1ul 3ul
    let result = ge a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``ge function. Normal Case2``() =
    let a = make Positive 2ul 3ul
    let b = make Negative 4ul 3ul
    let result = ge a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``ge function. Normal Case3``() =
    let a = make Positive 2ul 3ul
    let b = make Negative 2ul 3ul
    let result = ge a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``ge function. Normal Case4``() =
    let a = make Negative 2ul 3ul
    let b = make Negative 2ul 3ul
    let result = ge a b
    Assert.IsTrue (result)

  // lt function test
  [<TestMethod; Timeout(10000)>]
  member __.``lt function. Normal Case1``() =
    let a = make Positive 1ul 3ul
    let b = make Positive 2ul 3ul
    let result = lt a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``lt function. Normal Case2``() =
    let a = make Negative 1ul 3ul
    let b = make Positive 2ul 3ul
    let result = lt a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``lt function. Normal Case3``() =
    let a = make Negative 4ul 15ul
    let b = make Negative 17ul 133ul
    let result = lt a b
    Assert.IsTrue (result)

  // le function test
  [<TestMethod; Timeout(10000)>]
  member __.``le function. Normal Case1``() =
    let a = make Positive 1ul 3ul
    let b = make Positive 2ul 3ul
    let result = le a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``le function. Normal Case2``() =
    let a = make Positive 1ul 3ul
    let b = make Positive 1ul 3ul
    let result = le a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``le function. Normal Case3``() =
    let a = make Negative 1ul 5ul
    let b = make Negative 1ul 6ul
    let result = le a b
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``le function. Normal Case4``() =
    let a = make Positive 1ul 5ul
    let b = make Negative 1ul 6ul
    let result = le a b
    Assert.IsFalse (result)

  // minus function test
  [<TestMethod; Timeout(10000)>]
  member __.``minus function. Normal Case1``() =
    let a = make Positive 2ul 3ul
    let p = make Negative 2ul 3ul
    let result = equal p (minus a)
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``minus function. Normal Case2``() =
    let a = make Negative 3ul 4ul
    let p = make Negative 6ul 8ul
    let result = equal p (minus a)
    Assert.IsFalse (result)

  // abs function test
  [<TestMethod; Timeout(10000)>]
  member __.``abs function. Normal Case1``() =
    let a = make Negative 2ul 3ul
    let p = make Positive 2ul 3ul
    let result = equal p (abs a)
    Assert.IsTrue (result)

  [<TestMethod; Timeout(10000)>]
  member __.``abs function. Normal Case2``() =
    let a = make Positive 2ul 3ul
    let p = make Negative 2ul 3ul
    let result = equal p (abs a)
    Assert.IsFalse (result)

  // toInt function test
  [<TestMethod; Timeout(10000)>]
  member __.``toInt function. Normal Case1``() =
    let result = make Positive 14ul 7ul |> toInt
    Assert.AreEqual (2, result)

  [<TestMethod; Timeout(10000)>]
  member __.``toInt function. Normal Case2``() =
    let result = make Positive 9ul 2ul |> toInt
    Assert.AreEqual (5, result)

  [<TestMethod; Timeout(10000)>]
  member __.``toInt function. Normal Case3``() =
    let result = make Positive 1ul 10ul |> toInt
    Assert.AreEqual (0, result)

  [<TestMethod; Timeout(10000)>]
  [<ExpectedException(typedefof<ComputationErrorException>)>]
  member __.``toInt function. Edge Case1``() =
    make Positive 0x80000000ul 1ul |> toInt |> ignore

  [<TestMethod; Timeout(10000)>]
  [<ExpectedException(typedefof<ComputationErrorException>)>]
  member __.``toInt function. Edge Case2``() =
    make Negative 0x80000001ul 1ul |> toInt |> ignore

