module HW13.Main

[<EntryPoint>]
let main _ =
  let stmts = [ Add (Num 1, Num 2) ]
  match Evaluator.eval stmts with
  | Some v -> printfn "%d" v
  | None -> printfn "()"
  0
