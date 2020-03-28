namespace HW12

/// Raised when an invalid number is encountered. See the comment of num parser.
exception InvalidNumberException

module Parser =
  val char: char -> Parser<char>

  val string: string -> Parser<string>

  val letter: Parser<char>

  val letterOrDigit: Parser<char>

  val digit: Parser<char>

  val whitespace: Parser<char>

  val num: Parser<Expr>

  val var: Parser<Expr>

  val lparen: Parser<char>

  val rparen: Parser<char>

  val letbinding: Parser<Expr>

  val factor: Parser<Expr>

  val term: Parser<Expr>

  val expr: Parser<Expr>

  val stmt: Parser<Expr>

  val prog: Parser<Expr list>

  val run: string -> Result<Expr list * Input, string * ParserPosition>