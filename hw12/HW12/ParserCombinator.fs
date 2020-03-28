namespace HW12

/// Parser computation expression.
type Parser<'a> = {
  /// This function takes an "Input" and returns a result. For the "Ok" case, it
  /// returns a parsed value ('a) and an updated "Input". For the "Error" case,
  /// it returns the current line (string) and the current parser's position
  /// (ParserPosition).
  Parse: Input -> Result<'a * Input, string * ParserPosition>
}

module ParserCombinator =
  let runOnInput parser input =
    parser.Parse input

  let bind f p =
    let p input =
      match runOnInput p input with
      | Ok (v, remaining) -> runOnInput (f v) remaining
      | Error e -> Error e
    { Parse = p }

  let ret x = { Parse = (fun input -> Ok (x, input)) }

  type ParserBuilder () =
    member __.Bind (m, f) = bind f m
    member __.Return (m) = ret m
    member __.ReturnFrom (m) = m

  let parser = ParserBuilder ()

  let satisfy predicate =
    let p input =
      let input', char = Input.nextChar input
      match char with
      | None ->
        Error (Input.currentLine input, input.Pos)
      | Some first ->
        if predicate first then
          Ok (first, input')
        else
          Error (Input.currentLine input, input.Pos)
    { Parse = p }

  let andThen p1 p2 =
    parser {
      let! r1 = p1
      let! r2 = p2
      return (r1, r2)
    }

  let (.>>.) = andThen

  let orElse p1 p2 =
    let p input =
      match runOnInput p1 input with
      | Ok (v, remaining) -> Ok (v, remaining)
      | Error _ -> runOnInput p2 input
    { Parse = p }

  let (<|>) = orElse

  let choice parsers =
    List.reduce (<|>) parsers

  let map f parser =
    { Parse = fun input ->
        match runOnInput parser input with
        | Ok (v, remaining) -> Ok (f v, remaining)
        | Error e -> Error e }

  let (<!>) = map
  let (|>>) x f = map f x

  let rec sequence parsers =
    match parsers with
    | [] -> parser { return [] }
    | hd :: tl ->
      parser {
        let! h = hd
        let! t = sequence tl
        return h :: t
      }

  let rec parseZeroOrMore parser input =
    match runOnInput parser input with
    | Error e -> ([], input)
    | Ok (v, remaining) ->
      let v', remaining' = parseZeroOrMore parser remaining
      v :: v', remaining'

  let many parser =
    let p input =
      Ok (parseZeroOrMore parser input)
    { Parse = p }

  let many1 p =
    parser {
      let! head = p
      let! tail = many p
      return head :: tail
    }

  let opt parser =
    let some = parser |>> Some
    let none = ret None
    some <|> none

  let (.>>) p1 p2 =
    p1 .>>. p2
    |> map fst

  let (>>.) p1 p2 =
    p1 .>>. p2
    |> map snd
