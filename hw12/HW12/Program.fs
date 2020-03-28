module HW12.Main
open System 
[<EntryPoint>]
let main _ =
  Parser.run """
  let x = 2147483647 + 2
  let y = 42
  let z = x * y
  let p = x + y + z
  let q = x - (y + z)
  x * y * (z + p) - q
  """ |> Print.ppResult
  Console.ReadKey() |> ignore
  0
