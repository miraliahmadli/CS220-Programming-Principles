namespace HW12

open System

exception InvalidNumberException

module Parser =
  open ParserCombinator
  open System.Drawing

  let char charToMatch =
    satisfy (fun c -> c = charToMatch)

  let charListToStr lst =
    String (List.toArray lst)

  /// This is a parser for a string.
  let string (s: string): Parser<string> = 
            s
            |> List.ofSeq
            |> List.map char
            |> sequence
            |>> charListToStr

  let letter = satisfy Char.IsLetter

  let letterOrDigit = satisfy Char.IsLetterOrDigit

  let digit = satisfy Char.IsDigit

  let whitespace = satisfy Char.IsWhiteSpace

  /// This is a parser for an expression "Num". For any valid number x, this
  /// should return (Num x). Valid number here means an "integer" that can be
  /// represented with F#'s "int" type: any number between System.Int32.MinValue
  /// and System.Int32.MaxValue. If otherwise, you raise InvalidNumberException.
  let num: Parser<Expr> = 
        many whitespace >>. opt (char '-') .>>. many1 digit
        |>> (fun (sign,lst) ->match sign with
                                | Some c -> if (charListToStr lst).Length >10 then raise InvalidNumberException
                                            elif ((charListToStr lst) |> int64) > int64(2147483648u) then raise InvalidNumberException
                                            else  (- ((charListToStr lst) |> int64)) |> int |> Num
                                | None -> if (charListToStr lst).Length >10 then raise InvalidNumberException
                                          elif ((charListToStr lst) |> int64) > int64(2147483647) then raise InvalidNumberException
                                          else (charListToStr lst) |> int |> Num )

  let var =
    many whitespace >>. many1 letter .>>. many letterOrDigit
    |>> (fun (a, b) -> List.concat [a; b] |> charListToStr |> Var)

  let lparen =
    many whitespace >>. char '('

  let rparen =
    many whitespace >>. char ')'

  /// This is for typing the knot below. You don't need to fix this.
  let mutable exprRef = { Parse = (fun _ -> failwith "XXX") }
  let expr = { Parse = (fun input -> runOnInput exprRef input) }

  /// This is for typing the knot below. You don't need to fix this.
  let mutable termRef = { Parse = (fun _ -> failwith "XXX") }
  let term = { Parse = (fun input -> runOnInput termRef input) }

  /// This is a parser for a let-binding expression. We do not consider nested
  /// let-bindings for simplicity.
  let letbinding: Parser<Expr> =
        many whitespace >>. 
        string "let" >>. 
        many whitespace >>. many1 letter .>>. many letterOrDigit
        |>> (fun (a, b) -> List.concat [a; b] |> charListToStr) .>>.
        (many whitespace >>. char '=' >>. many whitespace >>. expr)
        |>> Let


  let add =
    many whitespace >>. char '+'
    |>> (fun _ p1 p2 -> Add (p1, p2))

  let sub =
    many whitespace >>. char '-'
    |>> (fun _ p1 p2 -> Sub (p1, p2))

  let mul =
    many whitespace >>. char '*'
    |>> (fun _ p1 p2 -> Mul (p1, p2))

  let div =
    many whitespace >>. char '/'
    |>> (fun _ p1 p2 -> Div (p1, p2))

  /// This function returns a parser for a binary operator (such as add, sub,
  /// ...). This function takes in three parsers and combine them to create a
  /// parser. For simplicity, we give a concrete implementation for add, sub,
  /// div, and mul parsers above.
  let binop op p1 p2: Parser<Expr> = 
       many whitespace >>. p1 .>>. op .>>. p2
       |>> fun ((fst,operator),snd) -> operator fst snd

  let factor =
    var <|> num <|> (lparen >>. expr .>> rparen)

  // Tying the knot.
  termRef <- choice
    [ binop (mul <|> div) factor term
      factor ]

  // Tying the knot.
  exprRef <- choice
    [ binop (add <|> sub) term expr
      term ]

  /// This is a parser for a statement of our simple language. A statement in
  /// this language is either a let-binding or an expression (expr).
  let stmt: Parser<Expr> = letbinding  <|> expr

  let prog = many1 stmt

  let run str =
    runOnInput prog (Input.fromStr str)
