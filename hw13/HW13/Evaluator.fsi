module HW13.Evaluator

/// Raised when an undeclared variable is encountered during evaluation.
exception UnknownVariableException

/// Raised when we encounter an invalid number at any point during the
//evaluation.
exception IntOverflowException

val eval: Expr list -> int option
