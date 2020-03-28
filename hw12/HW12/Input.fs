namespace HW12

open System

/// Representation of the current parser position in the code.
type ParserPosition = {
  /// LinePos represents the current line position of the code.
  LinePos: int
  /// ColumnPos represents the current column position of the code.
  ColumnPos: int
}

/// A representation of an input and its parsing state. This helps us remember
/// which line and which column of the given input is currently accessed by a
/// parser.
type Input = {
  /// Given input code of our CalcLang, this is an array of each line in the
  /// code.
  Lines: string []
  /// Current parser position.
  Pos: ParserPosition
}

module Input =
  let fromStr str =
    if String.IsNullOrEmpty (str) then
      { Lines = [||]; Pos = { LinePos = 0; ColumnPos = 0 } }
    else
      let newline = [| "\r\n"; "\n" |]
      let lines = str.Split (newline, StringSplitOptions.None)
      { Lines = lines; Pos = { LinePos = 0; ColumnPos = 0 } }

  let currentLine input =
    if input.Pos.LinePos < input.Lines.Length then
      input.Lines.[input.Pos.LinePos]
    else
      ""

  let nextChar input =
    if input.Pos.LinePos >= input.Lines.Length then
      input, None
    else
      let currentLine = currentLine input
      if input.Pos.ColumnPos < currentLine.Length then
        let char = currentLine.[input.Pos.ColumnPos]
        let pos = { input.Pos with ColumnPos = input.Pos.ColumnPos + 1 }
        { input with Pos = pos }, Some char
      else
        let pos = { ColumnPos = 0; LinePos = input.Pos.LinePos + 1 }
        { input with Pos = pos }, Some '\n'
