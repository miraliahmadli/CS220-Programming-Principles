namespace HW13.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open HW13

[<TestClass>]
type TestClass () =
  let curry x y = (x, y)

  let eval input = Evaluator.eval

  let checker ans input =
    input |> Evaluator.eval |> curry ans |> Assert.AreEqual

  [<TestMethod>]
  member __.``Eval Test1`` () =
    [ Let ("x",Add (Num 1,Num 2))
      Let ("y",Num 42)
      Let ("z",Mul (Var "x",Var "y"))
      Let ("p",Add (Var "x",Add (Var "y",Var "z")))
      Let ("q",Sub (Var "x",Add (Var "y",Var "z")))
      Sub (Mul (Var "x",Mul (Var "y",Add (Var "z",Var "p"))),Var "q") ]
    |> checker (Some 37587)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Simple Expression 1. Num`` () =
    [ Num 1 ]
    |> checker (Some 1)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Simple Expression 2. Add`` () =
    [ Add (Num 1, Num 3) ]
    |> checker (Some 4)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Simple Expression 3. Sub`` () =
    [ Sub (Num 1, Num 3) ]
    |> checker (Some -2)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Simple Expression 4. Mul`` () =
    [ Mul (Num 1, Num 3) ]
    |> checker (Some 3)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Simple Expression 5. Div`` () =
    [ Div (Num 1, Num 3) ]
    |> checker (Some 0)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Nested Expression 1.`` () =
    [ Add (Sub (Num 1, Num 2), Num 3) ]
    |> checker (Some 2)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Nested Expression 2.`` () =
    [ Sub (Num 1, Div (Num 2, Num 3)) ]
    |> checker (Some 1)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Nested Expression 3.`` () =
    [ Mul (Div (Num 1, Num 2), Num 3) ]
    |> checker (Some 0)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Nested Expression 4.`` () =
    [ Div (Num 1, Sub (Num 2, Num 3)) ]
    |> checker (Some -1)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Let Expression 1.`` () =
    [ Let ("x", Num 1) ]
    |> checker (None)

  [<TestMethod; Timeout(10000)>]
  member __.``Eval Let Expression 2.`` () =
    [ Let ("x", Num 1) ; Var "x" ]
    |> checker (Some 1)

  [<TestMethod; Timeout(10000)>]
  [<ExpectedException(typedefof<Evaluator.UnknownVariableException>)>]
  member __.``Undeclared Variable 1.`` () =
    [ Var "x" ]
    |> checker Evaluator.UnknownVariableException

  [<TestMethod; Timeout(10000)>]
  [<ExpectedException(typedefof<Evaluator.UnknownVariableException>)>]
  member __.``Undeclared Variable 2.`` () =
    [ Add (Num 1, Var "x") ]
    |> checker Evaluator.UnknownVariableException

  [<TestMethod; Timeout(10000)>]
  [<ExpectedException(typedefof<Evaluator.UnknownVariableException>)>]
  member __.``Undeclared Variable 3.`` () =
    [ Let ("x",Add (Num 1,Num 2))
      Let ("y",Num 42)
      Let ("z",Mul (Var "x",Var "y"))
      Let ("p",Add (Var "x",Add (Var "y",Var "z")))
      Let ("q",Sub (Var "w",Add (Var "y",Var "z")))
      Sub (Mul (Var "x",Mul (Var "y",Add (Var "z",Var "p"))),Var "q") ]
    |> checker Evaluator.UnknownVariableException
