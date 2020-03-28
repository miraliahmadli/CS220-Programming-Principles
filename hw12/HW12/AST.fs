namespace HW12

/// AST for a simple integer calculator language, called CalcLang.
type Expr =
  /// An integer.
  | Num of int
  /// A variable.
  | Var of string
  /// Addition.
  | Add of Expr * Expr
  /// Subtraction.
  | Sub of Expr * Expr
  /// Multiplication.
  | Mul of Expr * Expr
  /// Division.
  | Div of Expr * Expr
  /// Let binding of the form: `let var = expr`.
  | Let of string * Expr
