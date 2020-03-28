namespace HW12.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open HW12

[<TestClass>]
type TestClass () =
  let curry x y = (x, y)
  let expectOk =
    function Ok (r, _) -> r | _ -> Assert.Fail ("Expected Ok. Got Error."); []

  let checker ans input =
    input |> Parser.run |> expectOk |> curry ans |> Assert.AreEqual

  [<TestMethod>]
  member __.``Parser Test1`` () =
    """
    let x = 1 + 2
    let y = 42
    let z = x * y
    let p = x + y + z
    let q = x - y + z
    x * y * (z + p) - q
    """
    |> checker [ Let ("x",Add (Num 1,Num 2))
                 Let ("y",Num 42)
                 Let ("z",Mul (Var "x",Var "y"))
                 Let ("p",Add (Var "x",Add (Var "y",Var "z")))
                 Let ("q",Sub (Var "x",Add (Var "y",Var "z")))
                 Sub (Mul (Var "x",Mul (Var "y",Add (Var "z",Var "p"))),Var "q") ]

  [<TestMethod; Timeout(10000)>]
  member __.``string Test 1. Exact Match`` () =
    let parser = Parser.string "token"
    let r = parser.Parse <| Input.fromStr "token"
    let a : Result<string * Input, string * ParserPosition> =
      Ok ("token", {Lines = [|"token"|]; Pos = {LinePos = 0; ColumnPos = 5}})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``string Test 1. Match`` () =
    let parser = Parser.string "token"
    let r = parser.Parse <| Input.fromStr "token_start"
    let a : Result<string * Input, string * ParserPosition> =
      Ok ("token", {Lines = [|"token_start"|]; Pos = {LinePos = 0; ColumnPos = 5}})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``string Test 1. Failed`` () =
    let parser = Parser.string "token"
    let r = parser.Parse <| Input.fromStr "taken"
    let a : Result<string * Input, string * ParserPosition> =
      Error ("taken", {LinePos = 0; ColumnPos = 1})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``num Test 1. Match`` () =
    let r = Parser.num.Parse <| Input.fromStr "1"
    let a : Result<Expr * Input, string * ParserPosition> =
      Ok (Num 1, {Lines = [|"1"|]; Pos = {LinePos = 0; ColumnPos = 1}})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``num Test 2. Match with white space`` () =
    let r = Parser.num.Parse <| Input.fromStr " 1"
    let a : Result<Expr * Input, string * ParserPosition> =
      Ok (Num 1, {Lines = [|" 1"|]; Pos = {LinePos = 0; ColumnPos = 2}})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``num Test 3. Match with multi digits`` () =
    let r = Parser.num.Parse <| Input.fromStr "12"
    let a : Result<Expr * Input, string * ParserPosition> =
      Ok (Num 12, {Lines = [|"12"|]; Pos = {LinePos = 0; ColumnPos = 2}})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``letbinding Test 1. Match`` () =
    let r = Parser.letbinding.Parse <| Input.fromStr "let x=123"
    let a : Result<Expr * Input, string * ParserPosition> =
      Ok (Let ("x", Num 123), {Lines = [|"let x=123"|]; Pos = {LinePos = 0; ColumnPos = 9}})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``letbinding Test 2. Match with pretty printing`` () =
    let r = Parser.letbinding.Parse <| Input.fromStr "let x = 123"
    let a : Result<Expr * Input, string * ParserPosition> =
      Ok (Let ("x", Num 123), {Lines = [|"let x = 123"|]; Pos = {LinePos = 0; ColumnPos = 11}})
    Assert.AreEqual (r, a)

  [<TestMethod; Timeout(10000)>]
  member __.``Simple Expression 1. Num`` () =
    """
    1
    """
    |> checker [ Num 1 ]

  [<TestMethod; Timeout(10000)>]
  member __.``Simple Expression 2. Var`` () =
    """
    x
    """
    |> checker [ Var "x" ]

  [<TestMethod; Timeout(10000)>]
  member __.``Simple Expression 3. Add`` () =
    """
    1 + x
    """
    |> checker [ Add (Num 1, Var "x") ]

  [<TestMethod; Timeout(10000)>]
  member __.``Simple Expression 4. Sub`` () =
    """
    1 - x
    """
    |> checker [ Sub (Num 1, Var "x") ]

  [<TestMethod; Timeout(10000)>]
  member __.``Simple Expression 5. Mul`` () =
    """
    1 * x
    """
    |> checker [ Mul (Num 1, Var "x") ]

  [<TestMethod; Timeout(10000)>]
  member __.``Simple Expression 6. Div`` () =
    """
    1 / x
    """
    |> checker [ Div (Num 1, Var "x") ]

  [<TestMethod; Timeout(10000)>]
  member __.``Nested Expression`` () =
    """
    (1 + x) - (2 * y)
    """
    |> checker [ Sub (Add (Num 1, Var "x"), Mul (Num 2, Var "y")) ]
