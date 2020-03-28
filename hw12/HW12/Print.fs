module HW12.Print

let ppResult = function
  | Ok (v: Expr list, _) ->
    v |> List.iter (printfn "%A")
  | Error (line, pos) ->
    let caret = sprintf "%*s^" pos.ColumnPos ""
    printfn "%s" line
    printfn "%s error here." caret
